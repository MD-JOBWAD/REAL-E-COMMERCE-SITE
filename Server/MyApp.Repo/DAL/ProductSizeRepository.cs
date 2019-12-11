using MyApp.DAL;
using MyApp.DAL.Models;
using MyApp.DTO.ViewModels;
using MyApp.Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp.Repo.DAL.Repository
{
    public class ProductSizeRepository : IRepository<ProductSizeVM>
    {
        DataDbContext db;
        public ProductSizeRepository(DataDbContext _db)
        {
            db = _db;
        }

        public ProductSizeVM Add(ProductSizeVM psizevm)
        {
            ProductSize productSize = new ProductSize();
            productSize.Chest = psizevm.Chest;
            productSize.Shoulder = psizevm.Shoulder;
            productSize.Sleeve = psizevm.Sleeve;
            productSize.Weight = psizevm.Weight;
            productSize.IsCloth = psizevm.IsCloth;
            productSize.Lenth = psizevm.Lenth;
            productSize.Height = psizevm.Height;
            productSize.Width = psizevm.Width;
            productSize.Season = psizevm.Season;

            db.ProductSizes.Add(productSize);
            db.SaveChanges();
            psizevm.ID = productSize.ID;
            return psizevm;
        }

        public ProductSizeVM Get(long id)
        {
            ProductSizeVM productSizeVM = db.ProductSizes.Select(psizevm => new ProductSizeVM
            {
                ID = psizevm.ID,
                Chest = psizevm.Chest,
                Shoulder = psizevm.Shoulder,
                Sleeve = psizevm.Sleeve,
                Weight = psizevm.Weight,
                IsCloth = psizevm.IsCloth,
                Lenth = psizevm.Lenth,
                Height = psizevm.Height,
                Width = psizevm.Width,
                Season = psizevm.Season,
            }).Where(q => q.ID == id).FirstOrDefault();
            return productSizeVM;
        }

        public IEnumerable<ProductSizeVM> GetAll()
        {
            IEnumerable<ProductSizeVM> productSizeVMs = db.ProductSizes.Select(psizevm => new ProductSizeVM
            {
                ID = psizevm.ID,
                Chest = psizevm.Chest,
                Shoulder = psizevm.Shoulder,
                Sleeve = psizevm.Sleeve,
                Weight = psizevm.Weight,
                IsCloth = psizevm.IsCloth,
                Lenth = psizevm.Lenth,
                Height = psizevm.Height,
                Width = psizevm.Width,
                Season = psizevm.Season
            });
            return productSizeVMs;
        }

        public bool Remove(long id)
        {
            ProductSize productSize = db.ProductSizes.Find(id);
            db.ProductSizes.Remove(productSize);
            db.SaveChanges();
            return true;
        }

        public bool Remove(ProductSizeVM psizevm)
        {
            ProductSize productSize = db.ProductSizes.Find(psizevm.ID);
            db.ProductSizes.Remove(productSize);
            db.SaveChanges();
            return true;
        }

        public ProductSizeVM Update(ProductSizeVM psizevm)
        {
            ProductSize productSize = db.ProductSizes.Find(psizevm.ID);
            productSize.Chest = psizevm.Chest;
            productSize.Shoulder = psizevm.Shoulder;
            productSize.Sleeve = psizevm.Sleeve;
            productSize.Weight = psizevm.Weight;
            productSize.IsCloth = psizevm.IsCloth;
            productSize.Lenth = psizevm.Lenth;
            productSize.Height = psizevm.Height;
            productSize.Width = psizevm.Width;
            productSize.Season = psizevm.Season;

            db.Entry(productSize).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return psizevm;
        }
    }
}
