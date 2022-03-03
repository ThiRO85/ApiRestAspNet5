using ApiRestAspNet5_01.Models.Base;
using System.Collections.Generic;

namespace ApiRestAspNet5_01.Repositories.Generics
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T type);
        T FindById(long id);
        List<T> FindAll();
        T Update(T type);
        void Delete(long id);
        bool Exists(long id);
        List<T> FindWithPagegSearch(string query);
        int GetCount(string query);
    }
}
