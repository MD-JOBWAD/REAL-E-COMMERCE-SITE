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
    public class OrderStatusRepository : IRepository<OrderStatusVM>
    {
        DataDbContext db;
        public OrderStatusRepository(DataDbContext _db)
        {
            db = _db;
        }

        public OrderStatusVM Add(OrderStatusVM svm)
        {
            OrderStatus orderStatus = new OrderStatus();
            orderStatus.Caption = svm.Caption;
            orderStatus.IsActive = svm.IsActive;

            db.OrderStatuses.Add(orderStatus);
            db.SaveChanges();
            svm.ID = orderStatus.ID;
            return svm;
        }

        public OrderStatusVM Get(long id)
        {
            OrderStatusVM orderStatusVM = db.OrderStatuses.Select(svm => new OrderStatusVM
            {
               ID = svm.ID,
               Caption = svm.Caption,
               IsActive = svm.IsActive
            }).Where(q => q.ID == id).FirstOrDefault();
            return orderStatusVM;
        }

        public IEnumerable<OrderStatusVM> GetAll()
        {
            IEnumerable<OrderStatusVM> statusVMs = db.OrderStatuses.Select(svm => new OrderStatusVM
            {
                ID = svm.ID,
                Caption = svm.Caption,
                IsActive = svm.IsActive
            });
            return statusVMs;
        }

        public bool Remove(long id)
        {
            OrderStatus orderStatus = db.OrderStatuses.Find(id);
            db.OrderStatuses.Remove(orderStatus);
            db.SaveChanges();
            return true;
        }

        public bool Remove(OrderStatusVM svm)
        {
            OrderStatus orderStatus = db.OrderStatuses.Find(svm.ID);
            db.OrderStatuses.Remove(orderStatus);
            db.SaveChanges();
            return true;
        }

        public OrderStatusVM Update(OrderStatusVM svm)
        {
            OrderStatus orderStatus = db.OrderStatuses.Find(svm.ID);
            orderStatus.Caption = svm.Caption;
            orderStatus.IsActive = svm.IsActive;

            db.Entry(orderStatus).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return svm;
        }
    }
}
