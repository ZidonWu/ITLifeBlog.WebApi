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
        /// �����û�����ȡ���¼���
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<Article> FindListByUserName(string name);

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
        /// �����û�����ȡ��������
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int CountArticleByUserName(string name);

        /// <summary>
        /// ��ɾ������
        /// </summary>
        /// <param name="id"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        OperResult UpdateByDelete(int id, Expression<Func<Article, bool>> where);
    }
}
