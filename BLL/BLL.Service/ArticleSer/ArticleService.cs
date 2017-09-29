using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COM.Common;
using System.Linq.Expressions;

namespace BLL.Service.ArticleSer
{
    public class ArticleService : BaseService<Article>, IArticleService
    {
        OperResult result = new OperResult();

        public OperResult AddArticle(Article model)
        {
            Article article = new Article()
            {
                ArticleGuid = Guid.NewGuid().ToString(),
                Title = model.Title,
                Description = model.Description,
                Content = model.Content,
                CategoryId = model.Category.Id,
                CommentNum = model.CommentNum,
                CreateTime = DateTime.Now,
                IsPublish = true,
                IsDelete = false,
                LastUpdateTime = model.LastUpdateTime,
                ReadNum = model.ReadNum,
                Stars = model.Stars,
                UserId = model.UserId
            };
            var result = base.Add(article);
            return result;
        }

        public int CountArticle()
        {
            return Repository.Count();
        }

        public int CountArticle(Expression<Func<Article, bool>> where)
        {
            return Repository.Count(where);
        }

        public int CountArticleByUserName(string name)  
        {
            return Repository.Count(x => x.User.Name == name);
        }

        public IEnumerable<Article> FindAllList()
        {
            return Repository.FindList().Where(x => x.IsDelete == false);
        }

        public IEnumerable<Article> FindAllList(Expression<Func<Article, bool>> where)
        {
            return Repository.FindList(where).Where(x => x.IsDelete == false);
        }

        public IEnumerable<Article> FindListByUserName(string name)
        {
            return Repository.FindList(x => x.User.Name == name).Where(y => y.IsDelete == false);
        }

        public OperResult UpdateByDelete(int id, Expression<Func<Article, bool>> where)
        {
            var entity = Find(id);
            if (entity == null)
            {
                result.Code = 10;
                result.Flag = false;
                result.Message = "Title为【" + id + "】的文章不存在!";
            }
            else
            {
                entity.IsDelete = true;
                Repository.UpdateByDelete(entity, where);
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

        public OperResult UpdateByDelete(Expression<Func<Article, bool>> where)
        {
            var entity = Find(where);
            if (entity == null)
            {
                result.Code = 10;
                result.Flag = false;
                result.Message = "Title为【" + where + "】的文章不存在!";
            }
            else
            {
                entity.IsDelete = true;
                Repository.Update(entity);
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

    }
}