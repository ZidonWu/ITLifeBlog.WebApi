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
                CommentNum = model.CommentNum,
                CreateTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")),
                IsPublish = model.IsPublish,
                IsDeleted = false,
                LastUpdateTime = model.LastUpdateTime,
                ReadNum = model.ReadNum,
                Stars = model.Stars,
                UserId = model.UserId,
                CategoryId = model.CategoryId
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
            return Repository.FindList().Where(x => x.IsDeleted == false);
        }

        public IEnumerable<Article> FindAllList(Expression<Func<Article, bool>> where)
        {
            return Repository.FindList(where).Where(x => x.IsDeleted == false);
        }

        public IEnumerable<Article> FindListByUserName(string name)
        {
            return Repository.FindList(x => x.User.Name == name).Where(y => y.IsDeleted == false);
        }

        public OperResult UpdateByDelete(int id, Expression<Func<Article, bool>> where)
        {
            var entity = Find(id);
            if (entity == null)
            {
                result.Code = 10;
                result.Flag = false;
                result.Message = "TitleΪ��" + id + "�������²�����!";
            }
            else
            {
                entity.IsDeleted = true;
                Repository.UpdateByDelete(entity, where);
                if (IUnitOfWork.Commit() > 0)
                {
                    result.Code = 1;
                    result.Flag = true;
                    result.Message = "ɾ���ɹ�!";
                    result.Data = entity;
                }
                else
                {
                    result.Code = 0;
                    result.Flag = false;
                    result.Message = "ɾ��ʧ��!";
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
                result.Message = "TitleΪ��" + where + "�������²�����!";
            }
            else
            {
                entity.IsDeleted = true;
                Repository.Update(entity);
                if (IUnitOfWork.Commit() > 0)
                {
                    result.Code = 1;
                    result.Flag = true;
                    result.Message = "ɾ���ɹ�!";
                    result.Data = entity;
                }
                else
                {
                    result.Code = 0;
                    result.Flag = false;
                    result.Message = "ɾ��ʧ��!";
                }
            }
            return result;
        }

    }
}