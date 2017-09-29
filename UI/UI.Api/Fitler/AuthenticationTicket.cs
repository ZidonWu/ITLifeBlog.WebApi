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
    public  class AuthenticationTicket
    {
        public  IAccountService _accountService;

        public AuthenticationTicket()
        {

        }

        public AuthenticationTicket(IAccountService accountService)
        {
            _accountService = accountService;
        }
        //校验用户名密码
        public bool ValidateTicket(string encryptTicket)
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
