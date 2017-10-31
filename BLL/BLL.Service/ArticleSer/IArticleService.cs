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
        /// �����ʻ�Id��ȡ���¼���
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        IEnumerable<ArticleModel> FindListByAccountId(int accountId);

        /// <summary>
        /// �����ʻ�����ȡ���¼���
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        IEnumerable<Article> FindListByAccountName(string accountName); 

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns></returns>
        int CountArticle();

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int CountArticle(Expression<Func<Article, bool>> where);

        /// <summary>
        /// �����ʻ�����ȡ��������
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int CountArticleByAccountName(string accountName);  

        /// <summary>
        /// ��ɾ������
        /// </summary>
        /// <param name="id"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        OperResult UpdateByDelete(int id, Expression<Func<Article, bool>> where);

        /// <summary>
        /// ��ҳ ����
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<Article> FindPageList(Paging<Article> paging, string where = "");

        /// <summary>
        /// Homeչʾ
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        IQueryable<Article> FindPageList(Paging<Article> paging, int categoryId = -1);

        IQueryable<Article> FindPageListByAccountId(Paging<Article> paging, int accountId);    
    }
}
