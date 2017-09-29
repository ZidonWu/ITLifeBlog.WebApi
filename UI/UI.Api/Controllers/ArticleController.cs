using BLL.Service.ArticleSer;
using COM.Common;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Article> GetAllList()
        {
            var result = _articleService.FindAllList();
            return result;
        }

        /// <summary>
        /// 根据作者获取所有文章列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Article> GetListByUserName(string name)
        {
            var result = _articleService.FindListByUserName(name);
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
        public Article GetById(int id)
        {
            var result = _articleService.Find(id);
            return result;
        }

        /// <summary>
        /// 根据id更新文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public OperResult UpdateById(int id)
        {
            var result = _articleService.Update(id);
            return result;
        }

        /// <summary>
        /// 根据id删除文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public OperResult DeleteById(int id)
        {
            var result = _articleService.UpdateByDelete(id, x => x.IsDelete);
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
        public int GetCountByUserName(string name)
        {
            var result = _articleService.CountArticleByUserName(name);
            return result;
        }
    }
}
