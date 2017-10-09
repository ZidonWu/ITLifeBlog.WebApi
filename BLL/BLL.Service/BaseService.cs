using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COM.Common;
using System.Linq.Expressions;
using DAL.Repositories;
using DAL.Core;

namespace BLL.Service
{
    public class BaseService<T> : IBaseService<T> where T : EntityBase
    {
        protected IEntityRepository<T> Repository { get; set; }

        protected IUnitOfWork IUnitOfWork = ContextFactory.CurrentContext();

        OperResult result = new OperResult();

        public BaseService()
        {
            Repository = new EntityRepository<T>(IUnitOfWork);
        }

        public OperResult Add(T entity)
        {
            Repository.Add(entity);
            if (IUnitOfWork.Commit() > 0)
            {
                result.Code = 1;
                result.Flag = true;
                result.Message = "添加成功!";
                result.Data = entity;
            }
            else
            {
                result.Code = 0;
                result.Flag = false;
                result.Message = "添加失败!";
            }
            return result;
        }

        public OperResult Delete(int id)
        {
            var entity = Find(id);
            if (entity == null)
            {
                result.Code = 10;
                result.Flag = false;
                result.Message = "Id为【" + id + "】的记录不存在!";
            }
            else
            {
                Repository.Delete(entity);
                if (IUnitOfWork.Commit() > 0)
                {
                    result.Code = 1;
                    result.Flag = true;
                    result.Message = "删除成功!";
                    result.Data = entity;
                }
                else
                {
                    result.Code = 0;
                    result.Flag = false;
                    result.Message = "删除失败!";
                }
            }
            return result;
        }

        public OperResult Delete(T entity)
        {
            Repository.Delete(entity);
            if (IUnitOfWork.Commit() > 0)
            {
                result.Code = 1;
                result.Flag = true;
                result.Message = "删除成功!";
            }
            else
            {
                result.Code = 0;
                result.Flag = false;
                result.Message = "删除失败!";
            }
            return result;
        }

        public OperResult Delete(Expression<Func<T, bool>> where)
        {
            Repository.Delete(where);
            if (IUnitOfWork.Commit() > 0)
            {
                result.Code = 1;
                result.Flag = true;
                result.Message = "删除成功!";
            }
            else
            {
                result.Code = 0;
                result.Flag = false;
                result.Message = "删除失败!";
            }
            return result;
        }

        public T Find(int id)
        {
            return Repository.Find(id);
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return Repository.Find(where);
        }

        public IQueryable<T> FindList()
        {
            return Repository.FindList();
        }

        public IQueryable<T> FindList(Expression<Func<T, bool>> where)
        {
            return Repository.FindList(where);
        }

        public OperResult Update(T entity)
        {
            Repository.Update(entity);
            if (IUnitOfWork.Commit() > 0)
            {
                result.Code = 1;
                result.Flag = true;
                result.Message = "更新成功!";
                result.Data = entity;
            }
            else
            {
                result.Code = 0;
                result.Flag = false;
                result.Message = "更新失败!";
            }
            return result;
        }

        public OperResult Update(int id)
        {
            var entity = Find(id);
            if (entity == null)
            {
                result.Code = 10;
                result.Flag = false;
                result.Message = "Id为【" + id + "】的记录不存在!";
            }
            else
            {
                Repository.Update(entity);
                if (IUnitOfWork.Commit() > 0)
                {
                    result.Code = 1;
                    result.Flag = true;
                    result.Message = "更新成功!";
                    result.Data = entity;
                }
                else
                {
                    result.Code = 0;
                    result.Flag = false;
                    result.Message = "更新失败!";
                }
            }
            return result;
        }

        public OperResult Update(Expression<Func<T, bool>> where)
        {
            var entity = Find(where);
            if (entity == null)
            {
                result.Code = 10;
                result.Flag = false;
                result.Message = "Id为【" + entity.Id + "】的记录不存在!";
            }
            else
            {
                Repository.Update(entity);
                if (IUnitOfWork.Commit() > 0)
                {
                    result.Code = 1;
                    result.Flag = true;
                    result.Message = "更新成功!";
                    result.Data = entity;
                }
                else
                {
                    result.Code = 0;
                    result.Flag = false;
                    result.Message = "更新失败!";
                }
            }
            return result;
        }

        public Paging<T> FindPageList(Paging<T> paging)
        {
            paging.Items = Repository.FindPageList(paging.PageSize, paging.PageIndex, out paging.TotalNumber).ToList();
            return paging;
        }

        public Paging<T> FindPageList(Paging<T> paging, bool order)
        {
            paging.Items = Repository.FindPageList(paging.PageSize, paging.PageIndex, out paging.TotalNumber, order).ToList();
            return paging;
        }
    }
}
