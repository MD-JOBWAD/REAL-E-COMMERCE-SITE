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
    public class OrderRepository : IRepository<OrderVM>
    {
        DataDbContext db;
        public OrderRepository(DataDbContext _db)
        {
            db = _db;
        }

        public OrderVM Add(OrderVM ovm)
        {
            Order order = new Order();
            order.CustomerID = ovm.CustomerID;
            order.PaymentID = ovm.PaymentID;
            order.OrderStatusID = ovm.OrderStatusID;
            order.ShippingID = ovm.ShippingID;
            order.UserID = ovm.UserID;
            order.Discount = ovm.Discount;
            order.IsFullPaid = ovm.IsFullPaid;
            order.DTOrderDelivered = ovm.DTOrderDelivered;
            order.DTOrderPlaced = ovm.DTOrderPlaced;

            db.Orders.Add(order);
            db.SaveChanges();
            ovm.ID = order.ID;
            return ovm;
        }

        public OrderVM Get(long id)
        {
            OrderVM order = db.Orders.Select(ovm => new OrderVM
            {
                ID = ovm.ID,
                CustomerID = ovm.CustomerID,
                PaymentID = ovm.PaymentID,
                OrderStatusID = ovm.OrderStatusID,
                ShippingID = ovm.ShippingID,
                UserID = ovm.UserID,
                Discount = ovm.Discount,
                IsFullPaid = ovm.IsFullPaid,
                DTOrderDelivered = ovm.DTOrderDelivered,
                DTOrderPlaced = ovm.DTOrderPlaced
            }).Where(q => q.ID == id).FirstOrDefault();
            return order;
        }

        public IEnumerable<OrderVM> GetAll()
        {
            IEnumerable<OrderVM> orders = db.Orders.Select(ovm => new OrderVM
            {
                ID = ovm.ID,
                CustomerID = ovm.CustomerID,
                PaymentID = ovm.PaymentID,
                OrderStatusID = ovm.OrderStatusID,
                ShippingID = ovm.ShippingID,
                UserID = ovm.UserID,
                Discount = ovm.Discount,
                IsFullPaid = ovm.IsFullPaid,
                DTOrderDelivered = ovm.DTOrderDelivered,
                DTOrderPlaced = ovm.DTOrderPlaced
            });
            return orders;
        }

        public bool Remove(long id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return true;
        }

        public bool Remove(OrderVM ovm)
        {
            Order order = db.Orders.Find(ovm.ID);
            db.Orders.Remove(order);
            db.SaveChanges();
            return true;
        }

        public OrderVM Update(OrderVM ovm)
        {
            Order order = db.Orders.Find(ovm.ID);
            order.CustomerID = ovm.CustomerID;
            order.PaymentID = ovm.PaymentID;
            order.OrderStatusID = ovm.OrderStatusID;
            order.ShippingID = ovm.ShippingID;
            order.UserID = ovm.UserID;
            order.Discount = ovm.Discount;
            order.IsFullPaid = ovm.IsFullPaid;
            order.DTOrderDelivered = ovm.DTOrderDelivered;
            order.DTOrderPlaced = ovm.DTOrderPlaced;

            db.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return ovm;
        }
    }
}
