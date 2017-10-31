using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COM.Common;
using System.Linq.Expressions;
using BLL.Service.CategorySer;
using BLL.Service.AccountSer;
using BLL.Contract;

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
                CreateTime = model.CreateTime,
                IsPublish = model.IsPublish,
                IsDeleted = false,
                LastUpdateTime = model.LastUpdateTime,
                ReadNum = model.ReadNum,
                Stars = model.Stars,
                AccountId = model.AccountId,
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

        public int CountArticleByAccountName(string accountName)
        {
            return Repository.Count(x => x.Account.Name == accountName);
        }

        public IEnumerable<Article> FindAllList()
        {
            return Repository.FindList().Where(x => x.IsDeleted == false);
        }

        public IEnumerable<Article> FindAllList(Expression<Func<Article, bool>> where)
        {
            return Repository.FindList(where).Where(x => x.IsDeleted == false);
        }

        public IEnumerable<ArticleModel> FindListByAccountId(int accountId)
        {
            var result = Repository.FindList(x => x.Account.Id == accountId).Where(y => y.IsDeleted == false);
            List<ArticleModel> list = new List<ArticleModel>();
            ArticleModel articleModel = new ArticleModel();
            foreach (var item in result)
            {

                articleModel.Content = item.Content;
                articleModel.CreateTime = item.CreateTime;
                articleModel.Description = item.Description;
                articleModel.Id = item.Id;
                articleModel.ArticleGuid = item.ArticleGuid;
                articleModel.IsDeleted = item.IsDeleted;
                articleModel.IsPublish = item.IsPublish;
                articleModel.Title = item.Title;
                articleModel.AccountId = item.AccountId;
                articleModel.CategoryId = item.CategoryId;
                list.Add(articleModel);
            }
            return list;
        }

        public IEnumerable<Article> FindListByAccountName(string accountName)
        {
            return Repository.FindList(x => x.Account.Name == accountName).Where(y => y.IsDeleted == false);
        }

        public IQueryable<Article> FindPageList(Paging<Article> paging, string where = "")
        {
            IQueryable<Article> _list = Repository.FindList();
            if (!string.IsNullOrEmpty(where))
            {
                _list = _list.Where(b => b.Title.Contains(where));
            }
            _list = _list.OrderByDescending(b => b.CreateTime);
            paging.TotalNumber = _list.Count();
            return _list.Skip((paging.PageIndex - 1) * paging.PageSize).Take(paging.PageSize);
        }

        public IQueryable<Article> FindPageList(Paging<Article> paging, int categoryId = -1)
        {
            CategoryService categoryService = new CategoryService();
            Category category = categoryService.Find(categoryId);
            IQueryable<Article> _list = Repository.FindList().Where(b => b.IsPublish);
            if (category != null)
            {
                _list = _list.Where(b => b.Category.Id == category.Id);
            }
            _list = _list.OrderByDescending(b => b.CreateTime);
            paging.TotalNumber = _list.Count();
            return _list.Skip((paging.PageIndex - 1) * paging.PageSize).Take(paging.PageSize);
        }

        public IQueryable<Article> FindPageListByAccountId(Paging<Article> paging, int accountId)
        {
            AccountService accountService = new AccountService();
            Account account = accountService.Find(accountId);
            IQueryable<Article> _list = Repository.FindList().Where(b => b.IsPublish);
            if (account != null)
            {
                _list = _list.Where(b => b.Account.Id == account.Id);
            }
            _list = _list.OrderByDescending(b => b.CreateTime);
            paging.TotalNumber = _list.Count();
            return _list.Skip((paging.PageIndex - 1) * paging.PageSize).Take(paging.PageSize);
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
                entity.IsDeleted = true;
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
                entity.IsDeleted = true;
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