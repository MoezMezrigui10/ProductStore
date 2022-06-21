using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PS.Data.Infrastructures
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private IDataBaseFactory _dbFactory;
        DbSet<T> dbset{ get { return _dbFactory.DataContext.Set<T>();}}
        public RepositoryBase(IDataBaseFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> condition)
        {
            dbset.RemoveRange(dbset.Where(condition));
        }
        public virtual T Get(Expression<Func<T, bool>> condition)
        {
            return dbset.FirstOrDefault(condition);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.AsEnumerable();
        }
        public virtual T GetById(object id)
        {
            return dbset.Find(id);
        }
        //public virtual T GetById(string id)
        //{
        //    return dbset.Find(id);
        //}
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null)
        {
            if(condition!=null)
                return dbset.Where(condition).AsEnumerable();
            return dbset.AsEnumerable();
        }
        public virtual void Delete (T entity)
        {
            dbset.Remove(entity);
        }
        public virtual void Update(T entity)
        {
            dbset.Update(entity);
        }
    }
}
