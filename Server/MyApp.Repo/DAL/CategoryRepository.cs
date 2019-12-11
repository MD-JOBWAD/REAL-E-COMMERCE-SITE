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
    public class CategoryRepository : IRepository<CategoryVM>
    {
        DataDbContext db;

        public CategoryRepository(DataDbContext _db)
        {
            db = _db;
        }

        public CategoryVM Add(CategoryVM cvm)
        {
            Category category = new Category();
            category.Name = cvm.Name;
            category.ParentCategoryID = Convert.ToInt64(cvm.ParentCategoryID);
            category.DisplayOrder = Convert.ToInt64(cvm.DisplayOrder);
            category.IsActive = Convert.ToBoolean(cvm.IsActive);

            db.Categories.Add(category);
            db.SaveChanges();
            cvm.ID = category.ID;
            return cvm;
        }

        public CategoryVM Get(long id)
        {
            CategoryVM SingleCategory = db.Categories.Select(cvm => new CategoryVM
            {
                ID = cvm.ID,
                ParentCategoryID = cvm.ParentCategoryID,
                Name = cvm.Name,
                DisplayOrder = cvm.DisplayOrder,
                IsActive = cvm.IsActive
            }).Where(q => q.ID == id).FirstOrDefault();
            return SingleCategory;
        }

        public IEnumerable<CategoryVM> GetAll()
        {
            IEnumerable<CategoryVM> data = db.Categories.Select(cvm => new CategoryVM
            {
                ID = cvm.ID,
                ParentCategoryID = cvm.ParentCategoryID,
                Name = cvm.Name,
                DisplayOrder = cvm.DisplayOrder,
                IsActive = cvm.IsActive
            });
            return data;
        }    

        public bool Remove(long id)
        {
            Category c = db.Categories.Find(id);
            db.Categories.Remove(c);
            db.SaveChanges();
            return true;
        }

        public bool Remove(CategoryVM cvm)
        {
            Category c = db.Categories.Find(cvm.ID);
            db.Categories.Remove(c);
            db.SaveChanges();
            return true;
        }

        public CategoryVM Update(CategoryVM cvm)
        {
            Category category = db.Categories.Find(cvm.ID);
            category.Name = cvm.Name;
            category.ParentCategoryID = Convert.ToInt64(cvm.ParentCategoryID);
            category.DisplayOrder = Convert.ToInt64(cvm.DisplayOrder);
            category.IsActive = Convert.ToBoolean(cvm.IsActive);
            db.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return cvm;
        }
    }//c
}//ns