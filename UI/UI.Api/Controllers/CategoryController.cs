using BLL.Service.CategorySer;
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
    public class CategoryController : BaseApiController
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// 获取所有文章分类
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Category> GetAllList()
        {
            var result = _categoryService.FindList();
            return result;
        }
        
        /// <summary>
        /// 添加文章分类
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        public OperResult Add([FromBody]Category category)
        {
            var result = _categoryService.Add(category);
            return result;
        }

        [HttpGet]
        public Category GetById(int id)
        {
            var result = _categoryService.Find(id);
            return result;
        }

        /// <summary>
        /// 根据id更新指定的分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public OperResult UpdateById(int id)
        {
            var result = _categoryService.Update(id);
            return result;
        }

        /// <summary>
        /// 根据id删除指定的分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public OperResult DeleteById(int id)
        {
            var result = _categoryService.Delete(id);
            return result;
        }

        [HttpPost]
        [AllowAnonymous]
        public OperResult Update([FromBody]Category category)
        {
            var result = _categoryService.Update(category);
            return result;
        }
    }
}
