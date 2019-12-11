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
    public class MerchantRepository : IRepository<MerchantVM>
    {
        DataDbContext db;
        public MerchantRepository(DataDbContext _db)
        {
            db = _db;
        }

        public MerchantVM Add(MerchantVM mvm)
        {
            Merchant merchant = new Merchant();
            merchant.CompanyName = mvm.CompanyName;
            merchant.ProprietorName = mvm.ProprietorName;
            merchant.Password = mvm.Password;
            merchant.Mobile = mvm.Mobile;
            merchant.AlternativeMobile = mvm.AlternativeMobile;
            merchant.FbLink = mvm.FbLink;
            merchant.Address = mvm.Address;
            merchant.WebSiteName = mvm.WebSiteName;
            merchant.BankAccount = mvm.BankAccount;
            merchant.BussinessType = mvm.BussinessType;
            merchant.Location = mvm.Location;
            merchant.AccountHolderName = mvm.AccountHolderName;
            merchant.District = mvm.District;
            merchant.BankName = mvm.BankName;
            merchant.BranchName = mvm.BranchName;
            merchant.RoutingNumber = mvm.RoutingNumber;

            db.Merchants.Add(merchant);
            db.SaveChanges();
            mvm.MerchantID = merchant.MerchantID;
            return mvm;
        }

        public MerchantVM Get(long id)
        {
            MerchantVM merchantVM = db.Merchants.Select(mvm => new MerchantVM
            {
               MerchantID = mvm.MerchantID,
               CompanyName = mvm.CompanyName,
               ProprietorName = mvm.ProprietorName,
               Password = mvm.Password,
               Mobile = mvm.Mobile,
               AlternativeMobile = mvm.AlternativeMobile,
               FbLink = mvm.FbLink,
               Address = mvm.Address,
               WebSiteName = mvm.WebSiteName,
               BankAccount = mvm.BankAccount,
               BussinessType = mvm.BussinessType,
               Location = mvm.Location,
               AccountHolderName = mvm.AccountHolderName,
               District = mvm.District,
               BankName = mvm.BankName,
               BranchName = mvm.BranchName,
               RoutingNumber = mvm.RoutingNumber,
            }).Where(q => q.MerchantID == id).FirstOrDefault();
            return merchantVM;
        }

        public IEnumerable<MerchantVM> GetAll()
        {
            IEnumerable<MerchantVM> merchantVMs = db.Merchants.Select(mvm => new MerchantVM
            {
                MerchantID = mvm.MerchantID,
                CompanyName = mvm.CompanyName,
                ProprietorName = mvm.ProprietorName,
                Password = mvm.Password,
                Mobile = mvm.Mobile,
                AlternativeMobile = mvm.AlternativeMobile,
                FbLink = mvm.FbLink,
                Address = mvm.Address,
                WebSiteName = mvm.WebSiteName,
                BankAccount = mvm.BankAccount,
                BussinessType = mvm.BussinessType,
                Location = mvm.Location,
                AccountHolderName = mvm.AccountHolderName,
                District = mvm.District,
                BankName = mvm.BankName,
                BranchName = mvm.BranchName,
                RoutingNumber = mvm.RoutingNumber
            });
            return merchantVMs;
        }

        public bool Remove(long id)
        {
            Merchant merchant = db.Merchants.Find(id);
            db.Merchants.Remove(merchant);
            db.SaveChanges();
            return true;
        }

        public bool Remove(MerchantVM mvm)
        {
            Merchant merchant = db.Merchants.Find(mvm.MerchantID);
            db.Merchants.Remove(merchant);
            db.SaveChanges();
            return true;
        }

        public MerchantVM Update(MerchantVM mvm)
        {
            Merchant merchant = db.Merchants.Find(mvm.MerchantID);
            merchant.CompanyName = mvm.CompanyName;
            merchant.ProprietorName = mvm.ProprietorName;
            merchant.Password = mvm.Password;
            merchant.Mobile = mvm.Mobile;
            merchant.AlternativeMobile = mvm.AlternativeMobile;
            merchant.FbLink = mvm.FbLink;
            merchant.Address = mvm.Address;
            merchant.WebSiteName = mvm.WebSiteName;
            merchant.BankAccount = mvm.BankAccount;
            merchant.BussinessType = mvm.BussinessType;
            merchant.Location = mvm.Location;
            merchant.AccountHolderName = mvm.AccountHolderName;
            merchant.District = mvm.District;
            merchant.BankName = mvm.BankName;
            merchant.BranchName = mvm.BranchName;
            merchant.RoutingNumber = mvm.RoutingNumber;

            db.Entry(merchant).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return mvm;
        }
    }
}
