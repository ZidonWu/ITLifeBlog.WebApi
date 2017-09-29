using BLL.Service.ArticleCommentSer;
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
    public class ArticleCommentController : BaseApiController
    {
        private IArticleCommentService _articleCommentService;
        public ArticleCommentController(IArticleCommentService articleCommentService)
        {
            _articleCommentService = articleCommentService;
        }

        /// <summary>
        /// 添加文章评论
        /// </summary>
        /// <param name="articleComment"></param>
        /// <returns></returns>
        [HttpPost]
        public OperResult Add([FromBody]ArticleComment articleComment)
        {
            var result = _articleCommentService.Add(articleComment);
            return result;
        }

        /// <summary>
        /// 获取所有文章评论
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ArticleComment> GetAllList()
        {
            var result = _articleCommentService.FindList();
            return result;
        }


    }
}
