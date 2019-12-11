using MyApp.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Repo.DAL
{
    public class ProductImages
    {
        private readonly DataDbContext dbContext;

        public ProductImages(DataDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Delete(string name)
        {
            var result = dbContext.ProductImages.Find(name);
            if(result != null)
            {
                dbContext.ProductImages.Remove(result);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
