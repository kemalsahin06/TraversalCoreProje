using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TAdd(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> TGetList();
        T TGetByID(int id); // İDE YE GÖRE VERİ GETİRİLECEK
       // List<T> TGetByFilter(Expression<Func<T,bool>>filter); // şartlı listeleme işlemi yapacak

    }
}
