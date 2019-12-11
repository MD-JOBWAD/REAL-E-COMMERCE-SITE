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
    public class BrandRepository : IRepository<BrandVM>
    {
        DataDbContext db;
        public BrandRepository(DataDbContext _db)
        {
            db = _db;
        }
        public BrandVM Add(BrandVM bvm)
        {
            Brand brand = new Brand();
            brand.BandName = bvm.BandName;
            brand.CategoryID = bvm.CategoryID;
            brand.ParentBandID = bvm.ParentBandID;

            db.Brands.Add(brand);
            db.SaveChanges();
            bvm.ID = brand.ID;
            return bvm;
        }

        public BrandVM Get(long id)
        {
            BrandVM SingleBrand = db.Brands.Select(bvm => new BrandVM
            {
            ID = bvm.ID,
            BandName = bvm.BandName,
            CategoryID = bvm.CategoryID,
            ParentBandID = bvm.ParentBandID,
            }).Where(q => q.ID == id).FirstOrDefault();
            return SingleBrand;
        }

        public IEnumerable<BrandVM> GetAll()
        {
            IEnumerable<BrandVM> data = db.Brands.Select(bvm => new BrandVM
            {
                ID = bvm.ID,
                BandName = bvm.BandName,
                CategoryID = bvm.CategoryID,
                ParentBandID = bvm.ParentBandID,
            });
            return data;
        }

        public bool Remove(long id)
        {
            Brand brand = db.Brands.Find(id);
            db.Brands.Remove(brand);
            db.SaveChanges();
            return true;
        }

        public bool Remove(BrandVM bvm)
        {
            Brand brand = db.Brands.Find(bvm.ID);
            db.Brands.Remove(brand);
            db.SaveChanges();
            return true;
        }

        public BrandVM Update(BrandVM bvm)
        {
            Brand brand = db.Brands.Find(bvm.ID);
            brand.BandName = bvm.BandName;
            brand.CategoryID = bvm.CategoryID;
            brand.ParentBandID = bvm.ParentBandID;
            db.Entry(brand).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return bvm;
        }
    }
}
