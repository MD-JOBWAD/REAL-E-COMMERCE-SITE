using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyApp.DTO.Identity;
using MyApp.Identity.Models;
using MyApp.Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Repo.DAL.Identity
{
    public class UserRepository: IUserRepository<UserVM>
    {
        private  UserManager<ApplicationUser> userManager;
        

        public UserRepository(UserManager<ApplicationUser> _user)
        {
            userManager = _user;
            
        }

        public async Task<bool> Add(UserVM vm)
        {
            ApplicationUser newUser =  new ApplicationUser()
            {
                UserName = vm.UserName,
                Email = vm.Email,
                Address = vm.Address,
                DistrictID = vm.DistrictID,
                IsMale = vm.IsMale,
                PhoneNumber = vm.PhoneNumber,
            };
           var user = await userManager.CreateAsync(newUser, vm.Password);
            if (user.Succeeded)
            {
                if (vm.Role != null)
                {
                    await userManager.AddToRoleAsync(newUser, vm.Role);
                }
                if (vm.Roles != null)
                {
                    await userManager.AddToRolesAsync(newUser, vm.Roles);
                }
                
                return true;
            }
            return false;
        }

        public async Task<UserVM> Get(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            UserVM uvm = new UserVM();
            uvm.Id = user.Id;
            uvm.UserName = user.UserName;
            uvm.Email = user.Email;
            uvm.PhoneNumber = user.PhoneNumber;
            uvm.Address = user.Address;
            uvm.DistrictID = user.DistrictID;
            uvm.IsMale = user.IsMale;
            uvm.Roles = await userManager.GetRolesAsync(user);
            return uvm;
        }
        public async Task<UserVM> GetUserByUserVM(UserVM vm)
        {
            UserVM uvm = new UserVM();
            if ( vm.Email != null && new EmailAddressAttribute().IsValid(vm.Email))
            {
               var user = await userManager.FindByEmailAsync(vm.Email);
                uvm.Id = user.Id;
                uvm.UserName = user.UserName;
                uvm.Email = user.Email;
                uvm.PhoneNumber = user.PhoneNumber;
                uvm.Address = user.Address;
                uvm.DistrictID = user.DistrictID;
                uvm.IsMale = user.IsMale;
                uvm.Roles = await userManager.GetRolesAsync(user);
                return uvm;
            }
            else
            {
                var user = await userManager.FindByNameAsync(vm.UserName);
                uvm.Id = user.Id;
                uvm.UserName = user.UserName;
                uvm.Email = user.Email;
                uvm.PhoneNumber = user.PhoneNumber;
                uvm.Address = user.Address;
                uvm.DistrictID = user.DistrictID;
                uvm.IsMale = user.IsMale;
                uvm.Roles = await userManager.GetRolesAsync(user);
                return uvm;
            }
        }
        public async Task<bool> IsExist(UserVM vm)
        {
            ApplicationUser user = new ApplicationUser();
            if (vm.Email != null && new EmailAddressAttribute().IsValid(vm.Email))
            {
                user = await userManager.FindByEmailAsync(vm.Email);              
            }
            else
            {
                user = await userManager.FindByNameAsync(vm.UserName);
            }
            if (user != null)
            {
                return true;
            }

            return false;            
        }

        public async Task<IEnumerable<UserVM>> GetAll()
        {
            var users = await userManager.Users.ToListAsync();

            //    IEnumerable<UserVM> userList = users.Select(user => new UserVM
            //    {
            //        Id = user.Id,
            //        UserName = user.UserName,
            //        Email = user.Email,
            //        PhoneNumber = user.PhoneNumber,
            //        Address = user.Address,
            //        DistrictID = user.DistrictID,
            //        IsMale = user.IsMale,
            //        Roles = await userManager.GetRolesAsync(user)
            //});
            List<UserVM> userList = new List<UserVM>();
            foreach (var user in users)
            {
                List<string> roleList = new List<string>();
                var roles = await userManager.GetRolesAsync(user);
                foreach (var Role in roles)
                {
                    roleList.Add(Role);
                }
                userList.Add(new UserVM()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address,
                    DistrictID = user.DistrictID,
                    IsMale = user.IsMale,
                        Roles = roleList
                    });
            }
            return userList.ToList();
        }

        public async Task<bool> Remove(string id)
        {
            if (id != null)
            {
                var user = await userManager.FindByIdAsync(id);
                var delete = await userManager.DeleteAsync(user);
                return true;
            }
            /// is this user roles remove from role automitically  
            return false;
        }

        public async Task<bool> Update(string id, UserVM vm)
        {
            var model = await userManager.FindByIdAsync(id);
            var newRole = vm.Role;
            if (model != null)
            {
                model.UserName = vm.UserName;
                model.Address= vm.Address;
                model.Email = vm.Email;
                model.PhoneNumber = vm.PhoneNumber;
                model.DistrictID = vm.DistrictID;
                model.IsMale = vm.IsMale; 
                ///model.UserName = vm.Email;////Why I am assining UserName with Email I think This asintment is not required
                model.NormalizedEmail = vm.Email;
                model.NormalizedUserName = vm.Email;
                
            }

            //if (model.Email == model.UserName)
            //{
                var Roles = await userManager.GetRolesAsync(model);
                var userRoleRemove = await userManager.RemoveFromRolesAsync(model, Roles);

                if (userRoleRemove.Succeeded && newRole != null)
                {
                    await userManager.AddToRoleAsync(model, newRole);
                }
                var update = await userManager.UpdateAsync(model);//The updated UserName are same it should not preferable
                if (update.Succeeded)
                {
                    return true;
                }
            //}
            return false ;

        }

        public async Task<bool> ResetPassword(string newPassword, UserVM vm )
        {
            var user = await userManager.FindByNameAsync(vm.UserName);
            var Output = await userManager.ChangePasswordAsync(user, vm.Password, newPassword);
            if (Output.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<string> GetEmailConfirmationToken(UserVM vm)
        {
            ApplicationUser user = new ApplicationUser();
            if (vm.Email != null && new EmailAddressAttribute().IsValid(vm.Email))
            {
                user = await userManager.FindByEmailAsync(vm.Email);
            }
            else
            {
                user = await userManager.FindByNameAsync(vm.UserName);
            }

            string token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            return token;
        }

        public async Task<bool> ConfirmEmailVerification(string userid, string token)
        {
            var user = await userManager.FindByIdAsync(userid);
            IdentityResult result = await userManager.
                        ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> IsEmailVerified(UserVM vm)
        {
            ApplicationUser user = new ApplicationUser();

            if (vm.UserName != null)
            {
                user = await userManager.FindByNameAsync(vm.UserName);
            }
            else
            {
                user = await userManager.FindByEmailAsync(vm.Email);
            }
            if (user != null)
            {
                var result = await userManager.IsEmailConfirmedAsync(user);
                if (result)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<string> GetResetPasswordToken(UserVM vm)
        {
            ApplicationUser user = new ApplicationUser();
            if (vm.Email != null && new EmailAddressAttribute().IsValid(vm.Email))
            {
                user = await userManager.FindByEmailAsync(vm.Email);
            }
            else
            {
                user = await userManager.FindByNameAsync(vm.UserName);
            }

            string token = await userManager.GeneratePasswordResetTokenAsync(user);
            return token;
        }

        public async Task<bool> forgetPasswordReset(string token, UserVM vm)
        {
            var user = await userManager.FindByNameAsync(vm.UserName);
            if (user != null)
            {
                var result = await userManager.ResetPasswordAsync(user, token, vm.Password);
                if (result.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
