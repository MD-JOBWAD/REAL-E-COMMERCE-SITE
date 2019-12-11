using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyApp.DTO.Identity;
using MyApp.Repo.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Repo.DAL.Identity
{
    public  class RoleRepository : IAsyncRepository<RoleVM>
    {
        private readonly RoleManager<IdentityRole> roleManager;
       

        public RoleRepository(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }

        public async Task<bool> Add(RoleVM vm)
        {
            
            IdentityRole role = new IdentityRole();
            role.Name = vm.Name;
            var Output = await roleManager.CreateAsync(role);
            if (Output.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<RoleVM> Get(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            RoleVM roleVM = new RoleVM()
            {
                Id = role.Id,
                Name = role.Name
            };
            return roleVM;
        }
        public async Task<bool> IsExist(RoleVM vm)
        {
            IdentityRole role = await roleManager.FindByNameAsync(vm.Name)?? null;
            if (role != null)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<RoleVM>> GetAll()
        {
            return await roleManager.Roles.Select(role => new RoleVM
            {
                Id = role.Id,
                Name = role.Name
            }).ToListAsync();
            
        }

        public async Task<bool> Remove(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            await roleManager.DeleteAsync(role);
            return true;
        }

        public async Task<bool> Update(string id,RoleVM vm)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            role.Name = vm.Name;
            
            var update = await roleManager.UpdateAsync(role);
            if (update.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
