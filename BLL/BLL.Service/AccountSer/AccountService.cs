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
    public class AccountService : BaseService<Account>,IAccountService
    {
        public OperResult Login(string name,string password)
        {
            OperResult result = new OperResult();
            var account = base.Repository.Find(a => a.Name == name);
            if (account == null)
            {
                result.Code = 2;
                result.Message = "帐号为【"+ name +"】的管理员不存在!";
            }
            else if(account.Password == password)
            {
                result.Code = 1;
                result.Message = "登录成功!";
            }
            else
            {
                result.Code = 3;
                result.Message = "密码错误!";
            }
            return result;
        }

        public Account Find(string name)
        {
            return Repository.Find(a => a.Name == name);
        }

        public IEnumerable<AccountModel> FindListAccount()
        {
            List<AccountModel> list = new List<AccountModel>();
            var result = Repository.FindList();
            foreach (var item in result)
            {
                AccountModel accountModel = new AccountModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    RoleModel = new RoleModel()
                    {
                        Id = item.RoleId
                    }
                    
                };
                list.Add(accountModel);
            }
            return list;
        }
    }
}
