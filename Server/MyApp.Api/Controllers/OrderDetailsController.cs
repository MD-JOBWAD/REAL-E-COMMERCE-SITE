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
    public class OrderDetailsController : ControllerBase
    {
        private readonly IRepository<OrderDetailsVM> repository;

        public OrderDetailsController(IRepository<OrderDetailsVM> repository)
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
        public async Task<ActionResult<OrderDetailsVM>> Post(OrderDetailsVM detailsVM)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var data = repository.Add(detailsVM);
            return CreatedAtAction(nameof(data), new { id = data.ID }, data);
        }
        [HttpPut]
        public async Task<ActionResult<OrderDetailsVM>> Put(OrderDetailsVM detailsVM)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var mainData = repository.Get(detailsVM.ID);
                if (mainData == null)
                    return NotFound();
                var data = repository.Update(detailsVM);
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