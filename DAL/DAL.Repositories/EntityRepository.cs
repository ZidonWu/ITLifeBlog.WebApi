using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COM.Common;
using System.Linq.Expressions;
using System.Data.Entity;
using DAL.Core;

namespace DAL.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : EntityBase
    {
        protected DbContext Db { get; set; }

        public EntityRepository(IUnitOfWork DbContext)
        {
            Db = (DbContext)DbContext;
        }

        public void Add(T entity)
        {
            Db.Entry<T>(entity);
            Db.Set<T>().Add(entity);
        }

        public int Count()
        {
            return Db.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> where)
        {
            return Db.Set<T>().Count(where);
        }

        public void Delete(int id)
        {
            T entity = Find(id);
            Db.Entry<T>(entity);
            Db.Set<T>().Remove(entity);
        }

        public void Delete(T entity)
        {
            Db.Entry<T>(entity);
            Db.Set<T>().Remove(entity);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            var entity = Find(where);
            Db.Entry<T>(entity);
            Db.Set<T>().Remove(entity);
        }

        public T Find(int id)
        {
            return Db.Set<T>().Find(id);
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return Db.Set<T>().SingleOrDefault(where);
        }

        public IQueryable<T> FindList()
        {
            return Db.Set<T>();
        }

        public IQueryable<T> FindList(Expression<Func<T, bool>> where)
        {
            return Db.Set<T>().Where(where);
        }

        public IQueryable<T> FindList(Expression<Func<T, bool>> where, int number)
        {
            return Db.Set<T>().Where(where).Take(number);
        }

        public IQueryable<T> FindList(Expression<Func<T, bool>> where, OrderParam orderParam)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindList(Expression<Func<T, bool>> where, OrderParam[] orderParam, int number)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            var entity = Find(id);
            Db.Set<T>().Attach(entity);
            Db.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Update(T entity)
        {
            Db.Set<T>().Attach(entity);
            Db.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Update(Expression<Func<T, bool>> where)
        {
            var entity = Find(where);
            Db.Set<T>().Attach(entity);
            Db.Entry<T>(entity).State = EntityState.Modified;
        }

        public void UpdateByDelete(T entity, Expression<Func<T, bool>> where)
        {
            Db.Set<T>().Attach(entity);
            Db.Entry<T>(entity).Property(where).IsModified = true;
        }
    }
}
