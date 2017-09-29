using BLL.Service.AccountSer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Security;

namespace UI.Api.Fitler
{
    /// <summary>
    /// 自定义次特性用于接口的身份验证
    /// </summary>
    public class RequestAuthorizeAttribute : AuthorizeAttribute
    {
        public IAccountService _accountService;

        //AuthenticationTicket authenticationTicket = new AuthenticationTicket();

        public RequestAuthorizeAttribute()
        {
            _accountService = new AccountService();
        }

        //重写基类的验证方式，加入我们自定义的Ticket验证
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //从http请求的头里面获取身份验证信息，验证是否是请求发起方的ticket
            var authorization = actionContext.Request.Headers.Authorization;
            if ((authorization != null) && (authorization.Parameter != null))
            {
                //解密用户ticket,并校验用户名密码是否匹配
                var encryptTicket = authorization.Parameter;
                if (ValidateTicket(encryptTicket))
                {
                    base.IsAuthorized(actionContext);
                }
                /*if (authenticationTicket.ValidateTicket(encryptTicket))
                {
                    base.IsAuthorized(actionContext);
                }*/   
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
            //如果取不到身份验证信息，并且不允许匿名访问，则返回未验证401
            else
            {
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous) base.OnAuthorization(actionContext);
                else HandleUnauthorizedRequest(actionContext);
            }
        }



        //校验用户名密码        
        private bool ValidateTicket(string encryptTicket)
        {
            //解密Ticket
            var strTicket = FormsAuthentication.Decrypt(encryptTicket).UserData;

            //从Ticket里面获取用户名和密码
            var index = strTicket.IndexOf("&");
            string strName = strTicket.Substring(0, index);
            string strPwd = strTicket.Substring(index + 1);
            try
            {
                var result = _accountService.Login(strName, strPwd);
                if (result.Code == 1)
                {
                    return true;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            
            return false;
        }      
    }
}
