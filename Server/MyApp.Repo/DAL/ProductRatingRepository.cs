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
    public class ProductRatingRepository : IRepository<ProductRatingVM>
    {
        DataDbContext db;
        public ProductRatingRepository(DataDbContext _db)
        {
            db = _db;
        }

        public ProductRatingVM Add(ProductRatingVM rvm)
        {
            ProductRating productRating = new ProductRating();
            productRating.ProductID = rvm.ProductID;
            productRating.Star = rvm.Star;

            db.ProductRatings.Add(productRating);
            db.SaveChanges();
            rvm.ID = productRating.ID;
            return rvm;
        }

        public ProductRatingVM Get(long id)
        {
            ProductRatingVM ratingVM = db.ProductRatings.Select(rvm => new ProductRatingVM
            {
                ID = rvm.ID,
                ProductID = rvm.ProductID,
                Star = rvm.Star
            }).Where(q => q.ID == id).FirstOrDefault();
            return ratingVM;
        }

        public IEnumerable<ProductRatingVM> GetAll()
        {
            IEnumerable<ProductRatingVM> ratingVMs = db.ProductRatings.Select(rvm => new ProductRatingVM
            {
                ID = rvm.ID,
                ProductID = rvm.ProductID,
                Star = rvm.Star
            });
            return ratingVMs;
        }

        public bool Remove(long id)
        {
            ProductRating productRating = db.ProductRatings.Find(id);
            db.ProductRatings.Remove(productRating);
            db.SaveChanges();
            return true;
        }

        public bool Remove(ProductRatingVM rvm)
        {
            ProductRating productRating = db.ProductRatings.Find(rvm.ID);
            db.ProductRatings.Remove(productRating);
            db.SaveChanges();
            return true;
        }

        public ProductRatingVM Update(ProductRatingVM rvm)
        {
            ProductRating productRating  = db.ProductRatings.Find(rvm.ID);
            productRating.ProductID = rvm.ProductID;
            productRating.Star = rvm.Star;

            db.Entry(productRating).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return rvm;
        }
    }
}
