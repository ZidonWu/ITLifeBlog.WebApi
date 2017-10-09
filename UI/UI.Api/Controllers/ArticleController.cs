using BLL.Service.ArticleSer;
using COM.Common;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UI.Api.Controllers
{
    public class ArticleController : BaseApiController
    {
        private IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        /// <summary>
        /// 获取所有文章列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Article> GetAllList()
        {
            var result = _articleService.FindAllList();
            return result;
        }

        /// <summary>
        /// 根据用户Id获取所有文章列表
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Article> GetListByAccountId(int accountId)
        {
            var result = _articleService.FindListByAccountId(accountId);
            return result;
        }

        /// <summary>
        /// 根据用户名获取所有文章列表
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Article> GetListByAccountName(string accountName)
        {
            var result = _articleService.FindListByAccountName(accountName);
            return result;
        }

        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        public OperResult Add([FromBody]Article article)
        {
            var result = _articleService.AddArticle(article);
            return result;
        }

        /// <summary>
        /// 根据id查询文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public Article GetById(int id)
        {
            var result = _articleService.Find(id);
            return result;
        }

        [HttpPost]
        [AllowAnonymous]
        public OperResult Update([FromBody]Article article)
        {
            var result = _articleService.Update(article);
            return result;
        }

        /// <summary>
        /// 根据id更新文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public OperResult UpdateById(int id)
        {
            var result = _articleService.Update(id);
            return result;
        }

        /// <summary>
        /// 根据Id软删除文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public OperResult DeleteById(int id)
        {
            var result = _articleService.UpdateByDelete(id, x => x.IsDeleted);
            return result;
        }

        /// <summary>
        /// 获取文章总数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public int GetCount()
        {
            var result = _articleService.CountArticle();
            return result;
        }

        /// <summary>
        /// 获取文章总数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public int GetCountByAccountName(string accountName)
        {
            var result = _articleService.CountArticleByAccountName(accountName);
            return result;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Article> GetPageList(int? pageIndex, string where="")
        {
            Paging<Article> page = new Paging<Article>();
            page.PageIndex = pageIndex == null ? 1 : pageIndex.Value;
            page.PageSize = 10;
            page.Items = _articleService.FindPageList(page, "").ToList();
            return page.Items;
        }

        /// <summary>
        /// 根据文章分类分页查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Article> GetPageListByCategoryId(int? pageIndex, int id = -1)
        {
            Paging<Article> page = new Paging<Article>();
            page.PageIndex = pageIndex == null ? 1 : pageIndex.Value;
            page.PageSize = 10;
            page.Items = _articleService.FindPageList(page, id).ToList();
            return page.Items;
        }

        /// <summary>
        /// 根据作者分类分页查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Article> GetPageListByAccountId(int? pageIndex, int id = -1) 
        {
            Paging<Article> page = new Paging<Article>();
            page.PageIndex = pageIndex == null ? 1 : pageIndex.Value;
            page.PageSize = 10;
            page.Items = _articleService.FindPageListByAccountId(page, id).ToList();
            return page.Items;
        }
    }
}
