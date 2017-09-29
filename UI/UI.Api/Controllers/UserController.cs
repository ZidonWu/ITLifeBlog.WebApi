using BLL.Service.UserSer;
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
    public class UserController : BaseApiController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public OperResult Add([FromBody]User user)
        {
            var result = _userService.Add(user);
            return result;
        }

        /// <summary>
        /// 根据id获得用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public User GetById(int id)
        {
            var result = _userService.Find(id);
            return result;
        }

        [HttpGet]
        public User GetByName(string name)
        {
            var result = _userService.Find(name);
            return result;
        }

        /// <summary>
        /// 获得所有用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<User> GetAllList()
        {
            var result = _userService.FindList();
            return result;
        }

        /// <summary>
        /// 根据id更新用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public OperResult UpdateById(int id)
        {
            var result = _userService.Update(id);
            return result;
        }

        /// <summary>
        /// 根据id删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public OperResult DeleteById(int id)
        {
            var result = _userService.Delete(id);
            return result;
        }
    }
}
