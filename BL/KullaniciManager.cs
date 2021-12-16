using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class KullaniciManager //Kullanıcı crud işlemlerini bu class üzerinden yapacağız
    {
        DatabaseContext databaseContext = new DatabaseContext();
        public List<Kullanici> GetAll()
        {
            return databaseContext.Kullanicilar.ToList(); // Metot isminden önce List<Kullanici> yazdığımız için kullanıcı listesi döndürmek zorundayız!
        }
        public Kullanici Find(int id)
        {
            return databaseContext.Kullanicilar.Find(id); //Find metodu parametre kısmındaki int id bölümünden gelecek id değerine sahip kullanıcıyı bulup döndürür
        }
        public int Add(Kullanici kullanici)
        {
            databaseContext.Kullanicilar.Add(kullanici);
            return databaseContext.SaveChanges();
        }
        public int Update(Kullanici kullanici)
        {
            databaseContext.Kullanicilar.AddOrUpdate(kullanici);
            return databaseContext.SaveChanges();
        }
        public int Delete(Kullanici kullanici)
        {
            databaseContext.Kullanicilar.Remove(kullanici);
            return databaseContext.SaveChanges();
        }
    }
}
