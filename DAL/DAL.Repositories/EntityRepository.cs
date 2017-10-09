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
            return FindList(where, orderParam, 0);
        }

        public IQueryable<T> FindList(Expression<Func<T, bool>> where, OrderParam orderParam, int number)
        {
            OrderParam[] _orderParams = null;
            if (orderParam != null) _orderParams = new OrderParam[] { orderParam };
            return FindList(where, _orderParams, number);
        }

        public IQueryable<T> FindList(Expression<Func<T, bool>> where, OrderParam[] orderParams, int number)
        {
            var _list = Db.Set<T>().Where(where);
            var _orderParames = Expression.Parameter(typeof(T), "o");
            if (orderParams != null && orderParams.Length > 0)
            {
                bool _isFirstParam = true;
                for (int i = 0; i < orderParams.Length; i++)
                {
                    //根据属性名获取属性
                    var _property = typeof(T).GetProperty(orderParams[i].PropertyName);
                    //创建一个访问属性的表达式
                    var _propertyAccess = Expression.MakeMemberAccess(_orderParames, _property);
                    var _orderByExp = Expression.Lambda(_propertyAccess, _orderParames);
                    string _orderName;
                    if (_isFirstParam)
                    {
                        _orderName = orderParams[i].Method == OrderMethod.ASC ? "OrderBy" : "OrderByDescending";
                        _isFirstParam = false;
                    }
                    else _orderName = orderParams[i].Method == OrderMethod.ASC ? "ThenBy" : "ThenByDescending";
                    MethodCallExpression resultExp = Expression.Call(typeof(Queryable), _orderName, new Type[] { typeof(T), _property.PropertyType }, _list.Expression, Expression.Quote(_orderByExp));
                    _list = _list.Provider.CreateQuery<T>(resultExp);
                }
            }
            if (number > 0) _list = _list.Take(number);
            return _list;
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

        public IQueryable<T> FindPageList(int pageSize, int pageIndex, out int totalNumber)
        {
            OrderParam _orderParam = null;
            return FindPageList(pageSize, pageIndex, out totalNumber, _orderParam);
        }

        public IQueryable<T> FindPageList(int pageSize, int pageIndex, out int totalNumber, OrderParam orderParam)
        {
            return FindPageList(pageSize, pageIndex, out totalNumber, (T) => true, orderParam);
        }

        public IQueryable<T> FindPageList(int pageSize, int pageIndex, out int totalNumber, Expression<Func<T, bool>> where)
        {
            OrderParam _param = null;
            return FindPageList(pageSize, pageIndex, out totalNumber, where, _param);
        }

        public IQueryable<T> FindPageList(int pageSize, int pageIndex, out int totalNumber, Expression<Func<T, bool>> where, OrderParam orderParam)
        {
            OrderParam[] _orderParams = null;
            if (orderParam != null) _orderParams = new OrderParam[] { orderParam };
            return FindPageList(pageSize, pageIndex, out totalNumber, where, _orderParams);
        }

        public IQueryable<T> FindPageList(int pageSize, int pageIndex, out int totalNumber, Expression<Func<T, bool>> where, OrderParam[] orderParams)
        {
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 10;
            IQueryable<T> _list = Db.Set<T>().Where(where);
            var _orderParames = Expression.Parameter(typeof(T), "o");
            if (orderParams != null && orderParams.Length > 0)
            {
                for (int i = 0; i < orderParams.Length; i++)
                {
                    //根据属性名获取属性
                    var _property = typeof(T).GetProperty(orderParams[i].PropertyName);
                    //创建一个访问属性的表达式
                    var _propertyAccess = Expression.MakeMemberAccess(_orderParames, _property);
                    var _orderByExp = Expression.Lambda(_propertyAccess, _orderParames);
                    string _orderName = orderParams[i].Method == OrderMethod.ASC ? "OrderBy" : "OrderByDescending";
                    MethodCallExpression resultExp = Expression.Call(typeof(Queryable), _orderName, new Type[] { typeof(T), _property.PropertyType }, _list.Expression, Expression.Quote(_orderByExp));
                    _list = _list.Provider.CreateQuery<T>(resultExp);
                }
            }
            else
            {
                _list = _list.OrderBy(a => a.Id);
            }
            totalNumber = _list.Count();
            return _list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public IQueryable<T> FindPageList(int pageSize, int pageIndex, out int totalNumber, bool asc)
        {
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 10;
            IQueryable<T> _list = Db.Set<T>();
            if (asc)
            {
                _list = _list.OrderBy(a => a.Id);
            }
            else
            {
                _list = _list.OrderByDescending(a => a.Id);
            }
            totalNumber = _list.Count();
            return _list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}
