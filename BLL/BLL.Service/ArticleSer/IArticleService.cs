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
        /// 根据用户名获取文章集合
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<Article> FindListByUserName(string name);

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
        /// 根据用户名获取文章总数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int CountArticleByUserName(string name);

        /// <summary>
        /// 软删除文章
        /// </summary>
        /// <param name="id"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        OperResult UpdateByDelete(int id, Expression<Func<Article, bool>> where);
    }
}
