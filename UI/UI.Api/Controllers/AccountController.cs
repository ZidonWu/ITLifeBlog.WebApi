using BLL.Service.AccountSer;
using COM.Common;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace UI.Api.Controllers
{
    public class AccountController : BaseApiController
    {
        public IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public object Login(string name, string password)
        {
            var result = new OperResult();
            if (!VaildateAccount(name, password))
            {
                result.Flag = false;
                result.Message = "请求失败!";
                return result;
            }

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, name, DateTime.Now, DateTime.Now.AddHours(1), true, string.Format("{0}&{1}", name, password), FormsAuthentication.FormsCookiePath);

            var oAccount = new Account { BRes = true, Name = name, Password = password, Ticket = FormsAuthentication.Encrypt(ticket) };
            HttpContext.Current.Session[name] = oAccount;
            //result.Data = oAccount;
            //result.Code = 1;
            //result.Flag = true;
            //result.Message = "请求成功!";
            return oAccount;
        }

        /// <summary>
        /// 添加帐户接口
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpPost]
        public OperResult Add([FromBody]Account account)
        {
            var result = _accountService.Add(account);
            return result;
        }

        /// <summary>
        /// 获取所有帐户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Account> GetAllList()
        {
            var result = _accountService.FindList();
            return result;
        }

        /// <summary>
        /// 根据id获取指定帐户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Account GetById(int id)
        {
            var result = _accountService.Find(id);
            return result;
        }

        /// <summary>
        /// 根据name获取指定帐户
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public Account GetByName(string name)
        {
            var result = _accountService.Find(name);
            return result;
        }

        /// <summary>
        /// 根据id更新指定帐户
        /// </summary>
        /// <param name="account"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public OperResult UpdateById([FromBody]Account account, int id)
        {
            var result = _accountService.Find(id);
            result.Name = account.Name;
            result.Password = account.Password;
            result.RoleId = account.RoleId;
            var result2 = _accountService.Update(result);
            return result2;
        }

        /// <summary>
        /// 根据name更新指定帐户
        /// </summary>
        /// <param name="account"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPut]
        public OperResult UpdateByName([FromBody]Account account, string name)
        {
            var result = _accountService.Find(name);
            result.Name = account.Name;
            result.Password = account.Password;
            result.RoleId = account.RoleId;
            var result2 = _accountService.Update(result);
            return result2;
        }

        /// <summary>
        /// 根据id删除指定帐户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public OperResult DeleteById(int id)
        {
            var result = _accountService.Delete(id);
            return result;
        }

        /// <summary>
        /// 根据name删除指定帐户
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public OperResult DeleteByName(string name)
        {
            var result = _accountService.Delete(x => x.Name == name);
            return result;
        }




        /// <summary>
        /// 校验用户名密码
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        private bool VaildateAccount(string strName, string strPwd)
        {
            var result = _accountService.Login(strName, strPwd);
            if (result.Code == 1)
            {
                return true;
            }
            return false;
        }
    }
}
