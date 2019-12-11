using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.DTO.ViewModels;
using MyApp.Repo.Interface;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<OrderVM> repository;

        public OrderController(IRepository<OrderVM> repository)
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
        public async Task<ActionResult<OrderVM>> Post(OrderVM order)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var data = repository.Add(order);
            return CreatedAtAction(nameof(data), new { id = data.ID }, data);
        }
        [HttpPut]
        public async Task<ActionResult<OrderVM>> Put(OrderVM order)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var mainData = repository.Get(order.ID);
                if (mainData == null)
                    return NotFound();
                var data = repository.Update(order);
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
    }
}