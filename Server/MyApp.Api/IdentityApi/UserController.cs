using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.DTO;
using MyApp.DTO.Identity;
using MyApp.Identity;
using MyApp.Identity.Models;
using MyApp.Repo.DAL.Identity;
using MyApp.Repo.Interface;

namespace MyApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private IUserRepository<UserVM> userContext;

        public UserController(IUserRepository<UserVM> _user)
        {
            userContext = _user;
        }

        //Get: api/User
        [HttpGet]
        public IActionResult Get()
        {
                
            IList<UserVM> UserList = userContext.GetAll().Result.ToList();
            return Ok(UserList);
                       
        }
        //Get: api/User/Detail/id
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if (id != null)
            {
                var model = userContext.Get(id).Result;
                return Ok(model);
            }
            return BadRequest();

        }

        //Post: api/User
        [HttpPost]
        public IActionResult Post([FromBody]UserVM model)
        {
            if (ModelState.IsValid)
            {

              var Output =  userContext.Add(model);
                if (Output.Result == true)
                {
                    return Ok();
                }
            }
            return NoContent();
        }
        //Put: api/User/id
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]UserVM model)
        {
            if (id != null && ModelState.IsValid)
            {
                var UpdatedUser = userContext.Update(id, model);
                if (UpdatedUser.Result == true)
                {
                    return Ok();
                }
               
            }
            return NoContent();

        }
        //Delete: api/User/id
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (id != null)
            {
                var DeletedUser = userContext.Remove(id);
                if (DeletedUser.Result == true)
                {
                    return Ok();
                }
            }
            return NoContent();

        }
    }
}