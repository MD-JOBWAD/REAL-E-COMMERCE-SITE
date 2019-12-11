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
    public class InvoiceRepository : IRepository<InvoiceVM>
    {
        DataDbContext db;
        public InvoiceRepository(DataDbContext _db)
        {
            db = _db;
        }

        public InvoiceVM Add(InvoiceVM ivm)
        {

            Invoice invoice = new Invoice();
            invoice.OrderID = ivm.OrderID;
            invoice.UserID = ivm.UserID;
            invoice.SubTotal = ivm.SubTotal;
            invoice.DiscountRate = ivm.DiscountRate;
            invoice.TaxRate = ivm.TaxRate;
            invoice.GrandTotal = ivm.GrandTotal;
            invoice.Note = ivm.Note;

            db.Invoices.Add(invoice);
            db.SaveChanges();
            ivm.ID = invoice.ID;
            return ivm;
        }

        public InvoiceVM Get(long id)
        {
            InvoiceVM invoiceVM = db.Invoices.Select(ivm => new InvoiceVM
            {
                ID = ivm.ID,
                OrderID = ivm.OrderID,
                UserID = ivm.UserID,
                SubTotal = ivm.SubTotal,
                DiscountRate = ivm.DiscountRate,
                TaxRate = ivm.TaxRate,
                GrandTotal = ivm.GrandTotal,
                Note = ivm.Note,
            }).Where(q => q.ID == id).FirstOrDefault();
            return invoiceVM;
        }

        public IEnumerable<InvoiceVM> GetAll()
        {
            IEnumerable<InvoiceVM> invoiceVMs = db.Invoices.Select(ivm => new InvoiceVM
            {
                ID = ivm.ID,
                OrderID = ivm.OrderID,
                UserID = ivm.UserID,
                SubTotal = ivm.SubTotal,
                DiscountRate = ivm.DiscountRate,
                TaxRate = ivm.TaxRate,
                GrandTotal = ivm.GrandTotal,
                Note = ivm.Note
            });
            return invoiceVMs;
        }

        public bool Remove(long id)
        {
            Invoice invoice = db.Invoices.Find(id);
            db.Invoices.Remove(invoice);
            db.SaveChanges();
            return true;
        }

        public bool Remove(InvoiceVM ivm)
        {
            Invoice invoice = db.Invoices.Find(ivm.ID);
            db.Invoices.Remove(invoice);
            db.SaveChanges();
            return true;
        }

        public InvoiceVM Update(InvoiceVM ivm)
        {
            Invoice invoice = db.Invoices.Find(ivm.ID);
            invoice.OrderID = ivm.OrderID;
            invoice.UserID = ivm.UserID;
            invoice.SubTotal = ivm.SubTotal;
            invoice.DiscountRate = ivm.DiscountRate;
            invoice.TaxRate = ivm.TaxRate;
            invoice.GrandTotal = ivm.GrandTotal;
            invoice.Note = ivm.Note;

            db.Entry(invoice).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return ivm;
        }
    }
}
