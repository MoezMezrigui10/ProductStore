using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PS.Data.Infrastructures
{
    public interface IRepositoryBase<T> where T: class
    {
        public void Add(T entity);
        public void Delete(T entity);
        public void Delete(Expression<Func<T, bool>> condition);
        //Delete(p=>p.price<20)
        public void Update(T entity);
        public T Get(Expression<Func<T, bool>> condition);
        public T GetById(object id);
        //public T GetById(string id);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> GetMany(Expression<Func<T, bool>> condition=null);

    }
}
