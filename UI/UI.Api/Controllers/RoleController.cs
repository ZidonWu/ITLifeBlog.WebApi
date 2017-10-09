using BLL.Service.RoleSer;
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
    public class RoleController : BaseApiController
    {
        private IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        public OperResult Add([FromBody]Role role)
        {
            var result = _roleService.Add(role);
            return result;
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Role> GetAllList()
        {
            var result = _roleService.FindList();
            return result;
        }

        /// <summary>
        /// 根据id更新角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public OperResult UpdateById(int id)
        {
            var result = _roleService.Update(id);
            return result;
        }

        /// <summary>
        /// 根据id删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public OperResult DeleteById(int id)
        {
            var result = _roleService.Delete(id);
            return result;
        }
    }
}
