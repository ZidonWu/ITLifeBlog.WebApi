using BLL.Contract;
using COM.Common;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.ArticleSer
{
    public interface IArticleService : IBaseService<Article>
    {
        OperResult AddArticle(Article article);

        IEnumerable<Article> FindAllList();
        IEnumerable<Article> FindAllList(Expression<Func<Article, bool>> where);

        /// <summary>
        /// 根据帐户Id获取文章集合
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        IEnumerable<ArticleModel> FindListByAccountId(int accountId);

        /// <summary>
        /// 根据帐户名获取文章集合
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        IEnumerable<Article> FindListByAccountName(string accountName); 

        /// <summary>
        /// 获取文章总数
        /// </summary>
        /// <returns></returns>
        int CountArticle();

        /// <summary>
        /// 获取文章总数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int CountArticle(Expression<Func<Article, bool>> where);

        /// <summary>
        /// 根据帐户名获取文章总数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int CountArticleByAccountName(string accountName);  

        /// <summary>
        /// 软删除文章
        /// </summary>
        /// <param name="id"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        OperResult UpdateByDelete(int id, Expression<Func<Article, bool>> where);

        /// <summary>
        /// 分页 管理
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<Article> FindPageList(Paging<Article> paging, string where = "");

        /// <summary>
        /// Home展示
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        IQueryable<Article> FindPageList(Paging<Article> paging, int categoryId = -1);

        IQueryable<Article> FindPageListByAccountId(Paging<Article> paging, int accountId);    
    }
}
