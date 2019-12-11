using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyApp.DTO;
using MyApp.DTO.Identity;
using MyApp.Identity.Models;
using MyApp.Library;
using MyApp.Library.SentEmail;
using MyApp.Repo.Interface;

namespace MyApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserRepository<UserVM> userContext;
        private IHttpContextAccessor httpContextAccessor;
        private IAsyncRepository<RoleVM> roleContext;
        private ISignInRepository<LoginVM> loginContext;
        private ISentEmail sentEmail;
        public AccountController(IUserRepository<UserVM> _user, IHttpContextAccessor _httpContextAccessor,
                                  IAsyncRepository<RoleVM> roleContext, ISignInRepository<LoginVM> loginContext,
                                   ISentEmail sentEmail)
        {
            userContext = _user;
            httpContextAccessor = _httpContextAccessor;
            this.roleContext = roleContext;
            this.loginContext = loginContext;
            this.sentEmail = sentEmail;
        }

        //api/Account/login
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                UserVM userVM = new UserVM()
                {
                    UserName = model.UserName,
                    Email = model.UserName,
                    Password = model.Password
                };
                var userExist = userContext.IsExist(userVM).Result;
                var user = userContext.GetUserByUserVM(userVM).Result;

                if (userExist != false)
                {
                    var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                };

                    var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));


                    var token = new JwtSecurityToken(
                        issuer: "api/Account/login",
                        audience: "api/Account/login",
                        expires: DateTime.UtcNow.AddHours(1),
                        claims: claims,
                        signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)

                        );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });

                }

                return Unauthorized();

            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPost]
        [Route("SignIn")]
        public IActionResult SignIn(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                UserVM userVM = new UserVM()
                {
                    UserName = model.UserName,
                    Email = model.UserName,
                    Password = model.Password
                };

                ;
                if (userContext.IsExist(userVM).Result == false)
                {
                    ModelState.AddModelError("",
                    "User dose not Exist!");
                    return Unauthorized(ModelState);
                }
                if (userContext.IsEmailVerified(userVM).Result == false)
                {
                    ModelState.AddModelError("",
                    "Email is not confirmed!");
                    return new BadRequestObjectResult(ModelState);
                }

                  var result = loginContext.add(model).Result;
                    if (result == true)
                    {
                        var user = userContext.GetUserByUserVM(userVM).Result;
                        var claims = new[]
                        {
                           new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                           new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                        };

                        var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));


                        var token = new JwtSecurityToken(
                            issuer: "api/Account/login",
                            audience: "api/Account/login",
                            expires: DateTime.UtcNow.AddHours(1),
                            claims: claims,
                            signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)

                            );

                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            //expiration = token.ValidTo
                        });

                    }

            }
            return new BadRequestObjectResult(ModelState);
        }


        //api/Account/register
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody]UserVM model)
        {
            if (ModelState.IsValid)
            {
                RoleVM rvm = new RoleVM()
                {
                    Name = model.Role
                };
                if (!roleContext.IsExist(rvm).Result)
                {
                        ModelState.AddModelError("",
                         "role does ont exsit!");
                        return new BadRequestObjectResult(ModelState);
                }
                if (userContext.IsExist(model).Result)
                {
                    ModelState.AddModelError("",
                        "User is already exsit!");
                    return new BadRequestObjectResult(ModelState);
                }
                var Output = userContext.Add(model);
                if (Output.Result == true)
                {

                    string confirmationToken = userContext.GetEmailConfirmationToken(model).Result;
                    var user = userContext.GetUserByUserVM(model).Result;

                    string confirmationLink = Url.Action("ConfirmEmail", "Account",
                                 new {
                                     userid = user.Id,
                                     token = confirmationToken
                                 },
                                 protocol: HttpContext.Request.Scheme);

                    var result = sentEmail.SendEmailAsync(user.Email, "Confirm your Email", confirmationLink );
                    return Ok(true);
                }
               
            }

            // If we got this far, something failed, redisplay form
            return new BadRequestObjectResult(ModelState);
        }
        [HttpGet]
        [Route("ConfirmEmail")]
        public IActionResult ConfirmEmail(string userid, string token)
        {
            var user = userContext.Get(userid).Result;
            var result = userContext.ConfirmEmailVerification(userid, token).Result;

            if (result == true)
            {
                return Ok();
            }
            return NoContent();
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {

            loginContext.Remove();
            return Ok(true);

        }
        [HttpPost]
        [Route("resetPassword")]
        [Authorize]
        public IActionResult ResetPassword([FromBody]ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
               
                var userName = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                UserVM userVM = new UserVM()
                {
                    UserName = userName,
                    Password = model.OldPassword
                };

                if (userContext.ResetPassword(model.NewPassword, userVM).Result == false)
                {
                    ModelState.AddModelError("",
                          "Invalid Email or Password!");
                    return new BadRequestObjectResult(ModelState);
                }
                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPost]
        [Route("forgetPassword")]
        public IActionResult ForgetPassword([FromBody]string Email)
        {
            if (Email != null)
            {
                UserVM userVM = new UserVM()
                {
                    Email = Email
                };
                var userExist = userContext.IsExist(userVM).Result;
                if (userExist == true)
                {
                    //var user = userContext.GetUserByUserVM(userVM).Result;
                    var confirmationToken = userContext.GetResetPasswordToken(userVM).Result;

                    string confirmationLink = Url.Action("ConfirmEmailToken", "Account",
                                 new
                                 {
                                     token = confirmationToken
                                 },
                                 protocol: HttpContext.Request.Scheme);

                    sentEmail.SendEmailAsync(Email, "Confirm your Email For Reset Password", confirmationLink);
                    return Ok();
                }
            }

            return NoContent();
        }



        [HttpPost]
        [Route("forgetPasswordReset")]
        public IActionResult ForgetPassword([FromBody]ForgetPasswordVM vm)
        {
            if (ModelState.IsValid)
            {

                UserVM userVM = new UserVM()
                {
                    UserName = vm.UserName,
                    Password = vm.NewPassword,

                };
                var result = userContext.forgetPasswordReset(vm.Token, userVM).Result;
                if (result == true)
                {
                    return Ok();
                }
            }
           
            return NoContent();
        }
        [HttpGet]
        [Route("ConfirmEmailToken")]
        public IActionResult confirmEmailToken(string token)
        {
            
            if (token != null)
            {
                return Ok(token.ToString());
            }
            return NoContent();
        }

    }//controller
}