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
    public class ProductReviewRepository : IRepository<ProductReviewVM>
    {
        DataDbContext db;
        public ProductReviewRepository(DataDbContext _db)
        {
            db = _db;
        }

        public ProductReviewVM Add(ProductReviewVM rvm)
        {
            ProductReview productReview = new ProductReview();
            productReview.ProductID = rvm.ProductID;
            productReview.UserID = rvm.UserID;
            productReview.fkUserReviewGave = rvm.fkUserReviewGave;
            productReview.Review = rvm.Review;
            productReview.ReviewDate = rvm.ReviewDate;
            productReview.IsApproved = rvm.IsApproved;

            db.ProductReviews.Add(productReview);
            db.SaveChanges();
            rvm.ID = productReview.ID;
            return rvm;
        }

        public ProductReviewVM Get(long id)
        {
            ProductReviewVM productReviewVM = db.ProductReviews.Select(rvm => new ProductReviewVM
            {
                ID = rvm.ID,
                ProductID = rvm.ProductID,
                UserID = rvm.UserID,
                fkUserReviewGave = rvm.fkUserReviewGave,
                Review = rvm.Review,
                ReviewDate = rvm.ReviewDate,
                IsApproved = rvm.IsApproved,
            }).Where(q => q.ID == id).FirstOrDefault();
            return productReviewVM;
        }

        public IEnumerable<ProductReviewVM> GetAll()
        {
            IEnumerable<ProductReviewVM> productReviewVMs = db.ProductReviews.Select(rvm => new ProductReviewVM
            {
                ID = rvm.ID,
                ProductID = rvm.ProductID,
                UserID = rvm.UserID,
                fkUserReviewGave = rvm.fkUserReviewGave,
                Review = rvm.Review,
                ReviewDate = rvm.ReviewDate,
                IsApproved = rvm.IsApproved
            });
            return productReviewVMs;
        }

        public bool Remove(long id)
        {
            ProductReview productReview = db.ProductReviews.Find(id);
            db.ProductReviews.Remove(productReview);
            db.SaveChanges();
            return true;
        }

        public bool Remove(ProductReviewVM rvm)
        {
            ProductReview productReview = db.ProductReviews.Find(rvm.ID);
            db.ProductReviews.Remove(productReview);
            db.SaveChanges();
            return true;
        }

        public ProductReviewVM Update(ProductReviewVM rvm)
        {
            ProductReview productReview = db.ProductReviews.Find(rvm.ID);
            productReview.ProductID = rvm.ProductID;
            productReview.UserID = rvm.UserID;
            productReview.fkUserReviewGave = rvm.fkUserReviewGave;
            productReview.Review = rvm.Review;
            productReview.ReviewDate = rvm.ReviewDate;
            productReview.IsApproved = rvm.IsApproved;

            db.Entry(productReview).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return rvm;
        }
    }
}
