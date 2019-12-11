using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.DAL;
using MyApp.DAL.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductByCategoryController : Controller
    {
        private readonly DataDbContext dbContext;

        public ProductByCategoryController(DataDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public List<Product> Get(int id)
        {
            var products = dbContext.Products.Where(e => e.CategoryID == id).ToList();
            if(products != null)
            {
                return products;
            }
            return null;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
