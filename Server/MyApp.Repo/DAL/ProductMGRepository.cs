
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MyApp.DAL;
using MyApp.DAL.Models;
using MyApp.DTO.ViewModels;
using MyApp.Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Repo.DAL.Repository
{
    public class ProductMGRepository : IRepository<ProductImageVM>
    {
        DataDbContext db;
        private readonly IHostingEnvironment hostingEnvironment;

        public ProductMGRepository()
        {

        }
        public ProductMGRepository(DataDbContext _db, IHostingEnvironment hostingEnvironment)
        {
            db = _db;
            this.hostingEnvironment = hostingEnvironment;
        }
        public ProductImageVM Add(ProductImageVM mgvm)
        {
            //FileUploader
            ProductImage productImage = new ProductImage();
            productImage.ProductID = mgvm.ProductID;
            productImage.Caption = mgvm.Caption;
            //productImage.FilePath = mgvm.FilePath;
            productImage.Thumbnail1 = mgvm.Thumbnail1;
            productImage.Thumbnail2 = mgvm.Thumbnail2;
            productImage.Thumbnail3 = mgvm.Thumbnail3;
            productImage.IsDefault = mgvm.IsDefault;
            productImage.IsActive = mgvm.IsActive;

            var imagePath = 

            db.ProductImages.Add(productImage);
            db.SaveChanges();
            mgvm.ID = productImage.ID;
            return mgvm;
        }

        public List<ProductImageVM> GetbyId(long id)
        {
            var s = db.ProductImages;
            List<ProductImage> productImages = db.ProductImages.Where(e => e.ProductID == id).Select(e => e).ToList();
            List<ProductImageVM> productImageVMs = new List<ProductImageVM>();
            foreach(var productImage in productImages)
            {
                ProductImageVM productImageVM = new ProductImageVM
                {
                    Caption = productImage.Caption,
                    DisplayOrder = productImage.DisplayOrder,
                    FilePath = productImage.FilePath,
                    ID = productImage.ID,
                    IsActive = productImage.IsActive,
                    IsDefault = productImage.IsDefault,
                    ProductID = productImage.ProductID,
                    Thumbnail1 = productImage.Thumbnail1,
                    Thumbnail2 = productImage.Thumbnail2,
                    Thumbnail3 = productImage.Thumbnail3
                };
                productImageVMs.Add(productImageVM);
            }
            return productImageVMs;
        }

        public IEnumerable<ProductImageVM> GetAll()
        {
            IEnumerable<ProductImageVM> data = db.ProductImages.Select(mgvm => new ProductImageVM
            {
                ID = mgvm.ID,
                ProductID = mgvm.ProductID,
                Caption = mgvm.Caption,
                FilePath = mgvm.FilePath,
                DisplayOrder = mgvm.DisplayOrder,
                Thumbnail1 = mgvm.Thumbnail1,
                Thumbnail2 = mgvm.Thumbnail2,
                Thumbnail3 = mgvm.Thumbnail3,
                IsDefault = mgvm.IsDefault,
                IsActive = mgvm.IsActive
            });
            return data;
        }

        public bool Remove(long id)
        {
            ProductImage mgvm = db.ProductImages.Find(id);
            db.ProductImages.Remove(mgvm);
            db.SaveChanges();
            return true;
        }

        public bool Remove(ProductImageVM mgvm)
        {
            ProductImage productImage = db.ProductImages.Find(mgvm.ID);
            db.ProductImages.Remove(productImage);
            db.SaveChanges();
            return true;
        }

        public ProductImageVM Update(ProductImageVM mgvm)
        {
            ProductImage productImage = db.ProductImages.Find(mgvm.ID);
            productImage.ProductID = mgvm.ProductID;
            productImage.Caption = mgvm.Caption;
            //productImage.FilePath = mgvm.FilePath;
            productImage.Thumbnail1 = mgvm.Thumbnail1;
            productImage.Thumbnail2 = mgvm.Thumbnail2;
            productImage.Thumbnail3 = mgvm.Thumbnail3;
            productImage.IsDefault = mgvm.IsDefault;
            productImage.IsActive = mgvm.IsActive;

            db.Entry(productImage).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return mgvm;
        }

        
        public ProductImageVM Get(long id)
        {
            var s = db.ProductImages;
            throw new NotImplementedException();
        }
    }
}