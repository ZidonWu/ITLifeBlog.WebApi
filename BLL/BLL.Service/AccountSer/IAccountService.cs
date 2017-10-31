using BLL.Contract;
using COM.Common;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.AccountSer
{
    public interface IAccountService:IBaseService<Account>
    {
        /// <summary>
        /// 登陆接口
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        OperResult Login(string name,string password);

        /// <summary>
        /// 根据帐户名查询帐户数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Account Find(string name);

        /// <summary>
        /// 查询用户集合
        /// </summary>
        /// <returns></returns>
        IEnumerable<AccountModel> FindListAccount(); 
    }
}
