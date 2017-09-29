using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.UserSer
{
    public class UserService : BaseService<User>, IUserService
    {
        /// <summary>
        /// 根据用户名获取用户数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public User Find(string name)
        {
            return Repository.Find(a => a.Name == name);
        }
    }
}
