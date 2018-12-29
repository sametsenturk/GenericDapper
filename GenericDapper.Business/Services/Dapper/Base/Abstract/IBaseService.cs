using System;
using System.Collections.Generic;
using System.Text;

namespace GenericDapper.Business.Services.Dapper.Base.Abstract
{
    public interface IBaseService<T>
    {
        T Find(int id);
        T Get(string expression);
        List<T> GetAll();
        List<T> GetAllWithQuery(string expression);
        void Insert(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}
