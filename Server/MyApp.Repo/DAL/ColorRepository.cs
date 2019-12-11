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
    public class ColorRepository : IRepository<ColorVM>
    {
        DataDbContext db;
        public ColorRepository(DataDbContext _db)
        {
            db = _db;
        }

        public ColorVM Add(ColorVM cvm)
        {
            Color color = new Color();
            color.Name = cvm.Name;

            db.Colors.Add(color);
            db.SaveChanges();
            cvm.ID = color.ID;
            return cvm;
        }

        public ColorVM Get(long id)
        {
            ColorVM colorVM = db.Colors.Select(cvm => new ColorVM
            {
               ID = cvm.ID,
               Name = cvm.Name
            }).Where(q => q.ID == id).FirstOrDefault();
            return colorVM;
        }

        public IEnumerable<ColorVM> GetAll()
        {
            IEnumerable<ColorVM> colorVMs = db.Colors.Select(cvm => new ColorVM
            {
                ID = cvm.ID,
                Name = cvm.Name
            });
            return colorVMs;
        }

        public bool Remove(long id)
        {
            Color color = db.Colors.Find(id);
            db.Colors.Remove(color);
            db.SaveChanges();
            return true;
        }

        public bool Remove(ColorVM cvm)
        {
            Color color = db.Colors.Find(cvm.ID);
            db.Colors.Remove(color);
            db.SaveChanges();
            return true;
        }

        public ColorVM Update(ColorVM cvm)
        {
            Color color = db.Colors.Find(cvm.ID);
            color.Name = cvm.Name;

            db.Entry(color).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return cvm;
        }
    }
}
