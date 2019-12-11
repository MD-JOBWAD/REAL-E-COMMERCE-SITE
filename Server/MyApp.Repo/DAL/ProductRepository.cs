using MyApp.DAL;
using MyApp.DAL.Models;
using MyApp.DTO;
using MyApp.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MyApp.Repo.Interface
{
    public class ProductRepository : IRepository<ProductVM>
    {
        DataDbContext db;
        public ProductRepository(DataDbContext _db)
        {
            db = _db;
        }
        public ProductVM Add(ProductVM pvm)
        {
            Product product = new Product();
            product.Name = pvm.Name;
            product.BrandID = pvm.BrandID;
            product.CategoryID = pvm.CategoryID;
            product.DiscountPrice = Convert.ToDouble(pvm.DiscountPrice);
            product.Description = pvm.Description;
            product.IsActive = Convert.ToBoolean(pvm.IsActive);
            product.IsFavourite = Convert.ToBoolean(pvm.IsFavourite);
            product.MarketPrice = Convert.ToDouble(pvm.MarketPrice);
            product.SalesPrice = pvm.SalesPrice;
            product.StockQuantity = pvm.StockQuantity;
            product.SKU = pvm.SKU;

            db.Products.Add(product);
            db.SaveChanges();
            pvm.ID = product.ID;

            if (Convert.ToBoolean(pvm.IsCloth))
            {
                foreach (ClothSizes clothSize in pvm.ClothSizes)
                {
                    ProductSize size = new ProductSize
                    {
                        IsCloth = true,
                        Chest = (int)clothSize.Chest,
                        Sleeve = clothSize.Sleeve,
                        Shoulder = (int)clothSize.Shoulder,
                        Season = pvm.Season,
                        ProductId = (long)pvm.ID
                    };
                    db.ProductSizes.Add(size);
                    db.SaveChanges();
                }
            }
            else
            {
                if(pvm.OtherProductSize != null)
                {
                    foreach (OtherProductSize otherProductSize in pvm.OtherProductSize)
                    {
                        ProductSize size = new ProductSize
                        {
                            IsCloth = false,
                            Weight = otherProductSize.Width,
                            Height = otherProductSize.Height,
                            Lenth =  otherProductSize.Lenth,
                            Season = pvm.Season,
                            ProductId = (long)pvm.ID
                        };
                        db.ProductSizes.Add(size);
                        db.SaveChanges();
                    }
                }
            }

            if(pvm.Colors != null)
            {
                foreach (var color in pvm.Colors)
                {
                    ProductColor productColor = new ProductColor
                    {
                        ColorID = Convert.ToInt64(color.ColorID),
                        ProductID = (long)pvm.ID
                    };
                    db.ProductColors.Add(productColor);
                    db.SaveChanges();
                }
            }
            int i = 1;
            if(pvm.ImageName != null)
            {
                foreach (string imageName in pvm.ImageName)
                {
                    ProductImage productImage = new ProductImage
                    {
                        FilePath = imageName,
                        DisplayOrder = i,
                        ProductID = (long)pvm.ID,
                    };
                    i++;
                    db.ProductImages.Add(productImage);
                    db.SaveChanges();
                }
            }

            return pvm;
        }

        public ProductVM Get(long id)
        {
            ProductVM SingleProduct = db.Products.Select(pvm => new ProductVM
            {
                ID = pvm.ID,
                Name = pvm.Name,
                BrandID = pvm.BrandID,
                CategoryID = pvm.CategoryID,
                Description = pvm.Description,
                SKU = pvm.SKU,
                MarketPrice = pvm.MarketPrice,
                DiscountPrice = pvm.DiscountPrice,
                SalesPrice = pvm.SalesPrice,
                StockQuantity = pvm.StockQuantity,
                IsFavourite = pvm.IsFavourite,
                IsActive = pvm.IsActive
            }).Where(q => q.ID == id).FirstOrDefault();
            return SingleProduct;
        }

        public IEnumerable<ProductVM> GetAll()
        {
            IEnumerable<ProductVM> data = db.Products.Select(pvm => new ProductVM
            {
                ID = pvm.ID,
                Name = pvm.Name,
                BrandID = pvm.BrandID,
                CategoryID = pvm.CategoryID,
                Description = pvm.Description,
                SKU = pvm.SKU,
                MarketPrice = pvm.MarketPrice,
                DiscountPrice = pvm.DiscountPrice,
                SalesPrice = pvm.SalesPrice,
                StockQuantity = pvm.StockQuantity,
                IsFavourite = pvm.IsFavourite,
                IsActive = pvm.IsActive
            });
            return data;
        }

        public IEnumerable<ProductVM> GetFeaturePro()
        {
            IEnumerable<ProductVM> FeatureProCollection = db.Products.Select(pvm => new ProductVM
            {
                ID = pvm.ID,
                Name = pvm.Name,
                BrandID = pvm.BrandID,
                CategoryID = pvm.CategoryID,
                //ColorID = pvm.ColorID,
                //ProductSizeID = pvm.ProductSizeID,
                //Description = pvm.Description,
                //SKU = pvm.SKU,
                //MarketPrice = pvm.MarketPrice,
                //DiscountPrice = pvm.DiscountPrice,
                //SalesPrice = pvm.SalesPrice,
                //TotalViewed = pvm.TotalViewed,
                StockQuantity = pvm.StockQuantity,
                IsFavourite = pvm.IsFavourite,
                IsActive = pvm.IsActive
            }).Where(p => p.IsFavourite != false);
            return FeatureProCollection;
        }

        public bool Remove(long id)
        {
            Product p = db.Products.Find(id);
            db.Products.Remove(p);
            db.SaveChanges();
            return true;
        }

        public bool Remove(ProductVM pvm)
        {
            Product p = db.Products.Find(pvm.ID);
            db.Products.Remove(p);
            db.SaveChanges();
            return true;
        }

        public ProductVM Update(ProductVM pvm)
        {
            Product product = db.Products.Find(pvm.ID);
            product.Name = pvm.Name;
            product.BrandID = pvm.BrandID;
            product.CategoryID = pvm.CategoryID;
            //product.ColorID = pvm.ColorID;
            //product.ProductSizeID = pvm.ProductSizeID;
            //product.Description = pvm.Description;
            //product.SKU = pvm.SKU;
            //product.MarketPrice = pvm.MarketPrice;
            //product.DiscountPrice = pvm.DiscountPrice;
            //product.SalesPrice = pvm.SalesPrice;
            //product.TotalViewed = pvm.TotalViewed;
            //product.StockQuantity = pvm.StockQuantity;
            //product.IsFavourite = pvm.IsFavourite;
            //product.IsActive = pvm.IsActive;

            db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return pvm;
        }
        public IEnumerable<ProductVM> ProductWithCategory(long CatID)
        {
            IEnumerable<ProductVM> categoryProductList = db.Products.Select(pvm => new ProductVM
            {
                ID = pvm.ID,
                Name = pvm.Name,
                BrandID = pvm.BrandID,
                CategoryID = pvm.CategoryID,
                //ColorID = pvm.ColorID,
                //ProductSizeID = pvm.ProductSizeID,
                //Description = pvm.Description,
                //SKU = pvm.SKU,
                //MarketPrice = pvm.MarketPrice,
                //DiscountPrice = pvm.DiscountPrice,
                //SalesPrice = pvm.SalesPrice,
                //TotalViewed = pvm.TotalViewed,
                StockQuantity = pvm.StockQuantity,
                IsFavourite = pvm.IsFavourite,
                IsActive = pvm.IsActive
            }).Where(proList => proList.CategoryID == CatID);
            return categoryProductList;
        }
    }//c
}//ns