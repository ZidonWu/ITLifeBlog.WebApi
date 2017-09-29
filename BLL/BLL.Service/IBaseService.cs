using COM.Common;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public interface IBaseService<T> where T : EntityBase
    {
        /// <summary>
        /// 根据id查询单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find(int id);

        /// <summary>
        /// 查询单条数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        T Find(Expression<Func<T, bool>> where);

        /// <summary>
        /// 查询数据集合
        /// </summary>
        /// <returns></returns>
        IQueryable<T> FindList();

        /// <summary>
        /// 查询数据集合
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<T> FindList(Expression<Func<T, bool>> where);

        OperResult Add(T entity);
        OperResult Update(int id);
        OperResult Update(T entity);
        OperResult Update(Expression<Func<T, bool>> where);
        OperResult Delete(int id);
        OperResult Delete(T entity);
        OperResult Delete(Expression<Func<T, bool>> where);
    }
}
