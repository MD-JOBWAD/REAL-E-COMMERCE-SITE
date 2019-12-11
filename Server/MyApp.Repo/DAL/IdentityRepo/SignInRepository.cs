using Microsoft.AspNetCore.Identity;
using MyApp.DTO.Identity;
using MyApp.Identity;
using MyApp.Identity.Models;
using MyApp.Repo.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repo.DAL.Identity
{
    public class SignInRepository : ISignInRepository<LoginVM>
    {

        SignInManager<ApplicationUser> loginManager;
        public SignInRepository(SignInManager<ApplicationUser> loginManager)
        {
            this.loginManager = loginManager;
        }
        public async Task<bool> add(LoginVM vm)
        {
        var result = await loginManager.PasswordSignInAsync
        (vm.UserName, vm.Password,
          vm.RememberMe, false);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Remove()
        {
            await loginManager.SignOutAsync();
            return true;
        }
    }
}
