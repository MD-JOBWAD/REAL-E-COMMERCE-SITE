using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.DTO.ViewModels;
using MyApp.Repo.DAL.Repository;
using MyApp.Repo.Interface;
using MyLibrary.FileUploader;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IRepository<ProductImageVM> repository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly Repo.DAL.ProductImages productImage;
        private readonly ProductMGRepository productMGRepository;

        public ProductImageController(IRepository<ProductImageVM> repository, IHostingEnvironment hostingEnvironment,
                                        MyApp.Repo.DAL.ProductImages productImage, ProductMGRepository productMGRepository)
        {
            this.repository = repository;
            this.hostingEnvironment = hostingEnvironment;
            this.productImage = productImage;
            this.productMGRepository = productMGRepository;
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
            var data = productMGRepository.GetbyId(id);
            if (data != null)
                return Ok(data);
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<ProductImageVM>> Post(List<IFormFile> files)
        {
            foreach(var file in files)
            {
                FileUploader.Upload(file, hostingEnvironment);
            }
            return null;
        }
        [HttpPut]
        public async Task<ActionResult<ProductImageVM>> Put(ProductImageVM imageVM)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var mainData = repository.Get(imageVM.ID);
                if (mainData == null)
                    return NotFound();
                var data = repository.Update(imageVM);
                return data;
            }
        }
        [HttpDelete]
        public ActionResult Delete(string name)
        {
           bool result = productImage.Delete(name);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}