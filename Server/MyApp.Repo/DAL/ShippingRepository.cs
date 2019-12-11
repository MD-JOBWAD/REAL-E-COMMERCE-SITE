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
    public class ShippingRepository : IRepository<ShippingVM>
    {
        DataDbContext db;
        public ShippingRepository(DataDbContext _db)
        {
            db = _db;
        }

        public ShippingVM Add(ShippingVM svm)
        {
            Shipping shipping = new Shipping();
            shipping.UserID = svm.UserID;
            shipping.UserName = svm.UserName;
            shipping.UserPhone = svm.UserPhone;
            shipping.UserEmail = svm.UserEmail;
            shipping.AddressLine1 = svm.AddressLine1;
            shipping.AddressLine2 = svm.AddressLine2;
            shipping.City = svm.City;
            shipping.Sate = svm.Sate;
            shipping.ZipCode = svm.ZipCode;
            shipping.Channel = svm.Channel;
            shipping.ShippingDate = svm.ShippingDate;

            db.Shippings.Add(shipping);
            db.SaveChanges();
            svm.ShippingID = shipping.ShippingID;
            return svm;
        }

        public ShippingVM Get(long id)
        {
            ShippingVM shippingVM = db.Shippings.Select(svm => new ShippingVM
            {
                ShippingID = svm.ShippingID,
                UserID = svm.UserID,
                UserName = svm.UserName,
                UserPhone = svm.UserPhone,
                UserEmail = svm.UserEmail,
                AddressLine1 = svm.AddressLine1,
                AddressLine2 = svm.AddressLine2,
                City = svm.City,
                Sate = svm.Sate,
                ZipCode = svm.ZipCode,
                Channel = svm.Channel,
                ShippingDate = svm.ShippingDate,
        }).Where(q => q.ShippingID == id).FirstOrDefault();
            return shippingVM;
        }

        public IEnumerable<ShippingVM> GetAll()
        {
            IEnumerable<ShippingVM> shippingVMs = db.Shippings.Select(svm => new ShippingVM
            {
                ShippingID = svm.ShippingID,
                UserID = svm.UserID,
                UserName = svm.UserName,
                UserPhone = svm.UserPhone,
                UserEmail = svm.UserEmail,
                AddressLine1 = svm.AddressLine1,
                AddressLine2 = svm.AddressLine2,
                City = svm.City,
                Sate = svm.Sate,
                ZipCode = svm.ZipCode,
                Channel = svm.Channel,
                ShippingDate = svm.ShippingDate
            });
            return shippingVMs;
        }

        public bool Remove(long id)
        {
            Shipping shipping = db.Shippings.Find(id);
            db.Shippings.Remove(shipping);
            db.SaveChanges();
            return true;
        }

        public bool Remove(ShippingVM svm)
        {
            Shipping shipping = db.Shippings.Find(svm.ShippingID);
            db.Shippings.Remove(shipping);
            db.SaveChanges();
            return true;
        }

        public ShippingVM Update(ShippingVM svm)
        {
            Shipping shipping = db.Shippings.Find(svm.ShippingID);
            shipping.UserID = svm.UserID;
            shipping.UserName = svm.UserName;
            shipping.UserPhone = svm.UserPhone;
            shipping.UserEmail = svm.UserEmail;
            shipping.AddressLine1 = svm.AddressLine1;
            shipping.AddressLine2 = svm.AddressLine2;
            shipping.City = svm.City;
            shipping.Sate = svm.Sate;
            shipping.ZipCode = svm.ZipCode;
            shipping.Channel = svm.Channel;
            shipping.ShippingDate = svm.ShippingDate;

            db.Entry(shipping).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return svm;
        }
    }
}
