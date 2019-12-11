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
    public class TransactionHistoryRepository : IRepository<TransactionHistoryVM>
    {
        DataDbContext db;
        public TransactionHistoryRepository(DataDbContext _db)
        {
            db = _db;
        }

        public TransactionHistoryVM Add(TransactionHistoryVM tvm)
        {
            TransectionHistory transectionHistory = new TransectionHistory();
            transectionHistory.OrderID = tvm.OrderID;
            transectionHistory.PayableAmount = tvm.PayableAmount;
            transectionHistory.PaidAmount = tvm.PaidAmount;
            transectionHistory.PaymentMedia = tvm.PaymentMedia;
            transectionHistory.PamentRefID = tvm.PamentRefID;
            transectionHistory.PaymentDate = tvm.PaymentDate;
            transectionHistory.DTPaid = tvm.DTPaid;
            transectionHistory.IsSuccess = tvm.IsSuccess;

            db.TransectionHistories.Add(transectionHistory);
            db.SaveChanges();
            tvm.ID = transectionHistory.ID;
            return tvm;
        }

        public TransactionHistoryVM Get(long id)
        {
            TransactionHistoryVM transactionHistoryVM = db.TransectionHistories.Select(tvm => new TransactionHistoryVM
            {
                ID = tvm.ID,
                OrderID = tvm.OrderID,
                PayableAmount = tvm.PayableAmount,
                PaidAmount = tvm.PaidAmount,
                PaymentMedia = tvm.PaymentMedia,
                PamentRefID = tvm.PamentRefID,
                PaymentDate = tvm.PaymentDate,
                DTPaid = tvm.DTPaid,
                IsSuccess = tvm.IsSuccess,
            }).Where(q => q.ID == id).FirstOrDefault();
            return transactionHistoryVM;
        }

        public IEnumerable<TransactionHistoryVM> GetAll()
        {
            IEnumerable<TransactionHistoryVM> transactionHistoryVMs = db.TransectionHistories.Select(tvm => new TransactionHistoryVM
            {
                ID = tvm.ID,
                OrderID = tvm.OrderID,
                PayableAmount = tvm.PayableAmount,
                PaidAmount = tvm.PaidAmount,
                PaymentMedia = tvm.PaymentMedia,
                PamentRefID = tvm.PamentRefID,
                PaymentDate = tvm.PaymentDate,
                DTPaid = tvm.DTPaid,
                IsSuccess = tvm.IsSuccess
            });
            return transactionHistoryVMs;
        }

        public bool Remove(long id)
        {
            TransectionHistory transectionHistory = db.TransectionHistories.Find(id);
            db.TransectionHistories.Remove(transectionHistory);
            db.SaveChanges();
            return true;
        }

        public bool Remove(TransactionHistoryVM tvm)
        {
            TransectionHistory transectionHistory = db.TransectionHistories.Find(tvm.ID);
            db.TransectionHistories.Remove(transectionHistory);
            db.SaveChanges();
            return true;
        }

        public TransactionHistoryVM Update(TransactionHistoryVM tvm)
        {
            TransectionHistory transectionHistory = db.TransectionHistories.Find(tvm.ID);
            transectionHistory.OrderID = tvm.OrderID;
            transectionHistory.PayableAmount = tvm.PayableAmount;
            transectionHistory.PaidAmount = tvm.PaidAmount;
            transectionHistory.PaymentMedia = tvm.PaymentMedia;
            transectionHistory.PamentRefID = tvm.PamentRefID;
            transectionHistory.PaymentDate = tvm.PaymentDate;
            transectionHistory.DTPaid = tvm.DTPaid;
            transectionHistory.IsSuccess = tvm.IsSuccess;

            db.Entry(transectionHistory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return tvm;
        }
    }
}
