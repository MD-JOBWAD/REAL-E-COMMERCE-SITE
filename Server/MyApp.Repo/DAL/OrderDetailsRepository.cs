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
    public class OrderDetailsRepository : IRepository<OrderDetailsVM>
    {
        DataDbContext db;
        public OrderDetailsRepository(DataDbContext _db)
        {
            db = _db;
        }

        public OrderDetailsVM Add(OrderDetailsVM odvm)
        {
            OrderDetails orderDetails = new OrderDetails();
            orderDetails.OrderID = odvm.OrderID;
            orderDetails.ProductID = odvm.ProductID;
            orderDetails.ShipingDate = odvm.ShipingDate;
            orderDetails.SigleItemPrice = odvm.SigleItemPrice;
            orderDetails.State = odvm.State;
            orderDetails.Quantity = odvm.Quantity;

            db.OrderDetails.Add(orderDetails);
            db.SaveChanges();
            odvm.ID = orderDetails.ID;
            return odvm;
        }

        public OrderDetailsVM Get(long id)
        {
            OrderDetailsVM detailsVM = db.OrderDetails.Select(odvm => new OrderDetailsVM
            {
               ID = odvm.ID,
               OrderID = odvm.OrderID,
               ProductID = odvm.ProductID,
               ShipingDate = odvm.ShipingDate,
               SigleItemPrice = odvm.SigleItemPrice,
               State = odvm.State,
               Quantity = odvm.Quantity,
            }).Where(q => q.ID == id).FirstOrDefault();
            return detailsVM;
        }

        public IEnumerable<OrderDetailsVM> GetAll()
        {
            IEnumerable<OrderDetailsVM> detailsVMs = db.OrderDetails.Select(odvm => new OrderDetailsVM
            {
                ID = odvm.ID,
                OrderID = odvm.OrderID,
                ProductID = odvm.ProductID,
                ShipingDate = odvm.ShipingDate,
                SigleItemPrice = odvm.SigleItemPrice,
                State = odvm.State,
                Quantity = odvm.Quantity
            });
            return detailsVMs;
        }

        public bool Remove(long id)
        {
            OrderDetails orderDetails = db.OrderDetails.Find(id);
            db.OrderDetails.Remove(orderDetails);
            db.SaveChanges();
            return true;
        }

        public bool Remove(OrderDetailsVM odvm)
        {
            OrderDetails orderDetails = db.OrderDetails.Find(odvm.ID);
            db.OrderDetails.Remove(orderDetails);
            db.SaveChanges();
            return true;
        }

        public OrderDetailsVM Update(OrderDetailsVM odvm)
        {
            OrderDetails orderDetails = db.OrderDetails.Find(odvm.ID);
            orderDetails.OrderID = odvm.OrderID;
            orderDetails.ProductID = odvm.ProductID;
            orderDetails.ShipingDate = odvm.ShipingDate;
            orderDetails.SigleItemPrice = odvm.SigleItemPrice;
            orderDetails.State = odvm.State;
            orderDetails.Quantity = odvm.Quantity;

            db.Entry(orderDetails).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return odvm;
        }
    }
}
