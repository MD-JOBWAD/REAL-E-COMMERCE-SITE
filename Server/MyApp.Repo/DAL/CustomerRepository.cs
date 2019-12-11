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
    public class CustomerRepository : IRepository<CustomerVM>
    {
        DataDbContext db;

        public CustomerRepository(DataDbContext _db)
        {
            db = _db;
        }

        public CustomerVM Add(CustomerVM cvm)
        {
            Customer customer = new Customer();
            customer.CustomerName = cvm.CustomerName;
            customer.Address = cvm.Address;
            customer.Gender = cvm.Gender;
            customer.Email = cvm.Email;
            customer.Mobile = cvm.Mobile;
            customer.Password = cvm.Password;
            customer.DeliveryAddress = cvm.DeliveryAddress;
            customer.DeliveryNumber = cvm.DeliveryNumber;

            db.Customers.Add(customer);
            db.SaveChanges();
            cvm.CustomerID = customer.CustomerID;
            return cvm;
        }

        public CustomerVM Get(long id)
        {
            CustomerVM customer = db.Customers.Select(cvm => new CustomerVM
            {
                CustomerID = cvm.CustomerID,
                CustomerName = cvm.CustomerName,
                Address = cvm.Address,
                Gender = cvm.Gender,
                Email = cvm.Email,
                Mobile = cvm.Mobile,
                Password = cvm.Password,
                DeliveryAddress = cvm.DeliveryAddress,
                DeliveryNumber = cvm.DeliveryNumber
            }).Where(q => q.CustomerID == id).FirstOrDefault();
            return customer;
        }

        public IEnumerable<CustomerVM> GetAll()
        {
            IEnumerable<CustomerVM> customers = db.Customers.Select(cvm => new CustomerVM
            {
                CustomerID = cvm.CustomerID,
                CustomerName = cvm.CustomerName,
                Address = cvm.Address,
                Gender = cvm.Gender,
                Email = cvm.Email,
                Mobile = cvm.Mobile,
                Password = cvm.Password,
                DeliveryAddress = cvm.DeliveryAddress,
                DeliveryNumber = cvm.DeliveryNumber
            });
            return customers;
        }

        public bool Remove(long id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return true;
        }

        public bool Remove(CustomerVM cvm)
        {
            Customer customer = db.Customers.Find(cvm.CustomerID);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return true;
        }

        public CustomerVM Update(CustomerVM cvm)
        {
            Customer customer = db.Customers.Find(cvm.CustomerID);
            customer.CustomerName = cvm.CustomerName;
            customer.Address = cvm.Address;
            customer.Gender = cvm.Gender;
            customer.Email = cvm.Email;
            customer.Mobile = cvm.Mobile;
            customer.Password = cvm.Password;
            customer.DeliveryAddress = cvm.DeliveryAddress;
            customer.DeliveryNumber = cvm.DeliveryNumber;

            db.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return cvm;
        }
    }
}
