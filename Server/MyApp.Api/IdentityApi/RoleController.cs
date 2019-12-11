using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.DTO;
using MyApp.DTO.Identity;
using MyApp.Repo.DAL.Identity;
using MyApp.Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private IAsyncRepository<RoleVM> roleContext;

        public RoleController(IAsyncRepository<RoleVM> _role)
        {
            roleContext = _role;
        }

     //Get: api/Role
        public IActionResult Get()
        {    
                var roles = roleContext.GetAll().Result.ToList();
                return Ok(roles);   
        }

    //Get: api/Role/Detail/id
      [HttpGet("{id}")]
       public IActionResult Get(string id)
        {

            if (id != null)
            {
                
             var model = roleContext.Get(id).Result;
             return Ok(model);

            }
            return BadRequest();
        }

        //Post: api/Role
        [HttpPost]
        public IActionResult Post([FromBody]RoleVM model)
        {
            if (ModelState.IsValid)
            {

                var Output = roleContext.Add(model);
                if (Output.Result == true)
                {
                    return Ok();
                }
            }
            return NoContent();
        }
        //Put: api/Role/id
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]RoleVM model)
        {
            if (id != null && ModelState.IsValid)
            {
                var Output = roleContext.Update(id, model);
                if (Output.Result == true)
                {
                    return Ok();
                }
            }
            return NoContent();

        }
        //Delete: api/Role/id
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (id != null)
            {
                var DeletedRole = roleContext.Remove(id);
                if (DeletedRole.Result == true)
                {
                    return Ok();
                }
            }
            return NoContent();

        }
    }
}
