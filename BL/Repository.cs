using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        DatabaseContext context; // Veritabanı tablolarımızı tutan DatabaseContext sınıfımız
        DbSet<T> _objectSet; // DatabaseContext sınıfı içerisindeki tabloların dbset lerini kullanabilmemizi sağlayacak nesnemiz
        public Repository()
        {
            if (context == null) // Eğer context null ise
            {
                context = new DatabaseContext(); // yeni bir DatabaseContext nesnesi oluştur
                _objectSet = context.Set<T>(); //_objectSet nesnesini context e gelen class a ayarla
            }
        }
        public int Add(T entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Find(int id)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
