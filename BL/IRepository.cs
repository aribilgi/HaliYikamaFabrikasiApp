using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    interface IRepository<T> // <T> yapısı ile bu interface i generic hale getirmiş olduk
    {
        List<T> GetAll(); // Tüm kayıtları listeleme metodumuz
        List<T> GetAll(Expression<Func<T, bool>> expression); // Kayıtları where ile sorgulayabilen metodumuz
        T Get(Expression<Func<T, bool>> expression); // Tek bir kaydı where ile sorgulayabilen metodumuz
        T Find(int id); // Kendisine gelen id ye sahip kaydı döndüren metodumuz
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        int SaveChanges();
    }
}
