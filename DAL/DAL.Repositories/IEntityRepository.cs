using COM.Common;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IEntityRepository<T> where T : EntityBase
    {
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// 根据id更新数据
        /// </summary>
        /// <param name="id"></param>
        void Update(int id);

        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="where"></param>
        void Update(Expression<Func<T, bool>> where);

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="where"></param>
        void UpdateByDelete(T entity, Expression<Func<T, bool>> where);

        /// <summary>
        /// 根据id删除数据
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="where"></param>
        void Delete(Expression<Func<T, bool>> where);

        /// <summary>
        /// 根据id查询实体数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find(int id);

        /// <summary>
        /// 查询实体数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        T Find(Expression<Func<T, bool>> where);

        IQueryable<T> FindList();
        IQueryable<T> FindList(Expression<Func<T, bool>> where);
        IQueryable<T> FindList(Expression<Func<T, bool>> where, int number);
        IQueryable<T> FindList(Expression<Func<T, bool>> where, OrderParam orderParam);
        IQueryable<T> FindList(Expression<Func<T, bool>> where, OrderParam[] orderParam, int number);

        /// <summary>
        /// 获得总数
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// 获得总数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> where);
    }
}
