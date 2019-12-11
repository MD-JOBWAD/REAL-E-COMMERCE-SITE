using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.DTO.ViewModels;
using MyApp.Repo.Interface;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<CategoryVM> repository;

        public CategoryController(IRepository<CategoryVM> repository)
        {
            this.repository = repository;
        }

        public ActionResult Get()
        {
            var data = repository.GetAll();
            if (data != null)
                return Ok(data);
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var data = repository.Get(id);
            if (data != null)
                return Ok(data);
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<CategoryVM>> Post(CategoryVM category)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var data = repository.Add(category);
            return CreatedAtAction(nameof(Get), new { id = data.ID }, data);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryVM>> Put(CategoryVM category)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var mainData = repository.Get(category.ID);
                if (mainData == null)
                    return NotFound();
                var data = repository.Update(category);
                return data;
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var mainData = repository.Get(id);
            if (mainData == null)
                return NotFound();
            var data = repository.Remove(id);
            if (data)
                return NoContent();
            return NotFound();
        }
        //[HttpPost]
        
        //public async Task post()
        //{
        //    HttpResponseMessage response = new HttpResponseMessage();
        //    var httpRequest = HttpContext.Request;
        //    var id = httpRequest.Form["id"];
        //    var name = httpRequest.Form["name"];
        //    var fileName = httpRequest.Form.Files[0];
        //}
    }
    public class CategoryTest
    {
        public int ID { get; set; }
        public string file { get; set; }
        //public long? ID { get; set; }
        //public string Name { get; set; }
        //public long? ParentCategoryID { get; set; }
        //public long? DisplayOrder { get; set; }
        //public bool? IsActive { get; set; }
    }
}