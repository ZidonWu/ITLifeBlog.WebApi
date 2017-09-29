using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.UserSer
{
    public interface IUserService : IBaseService<User>
    {
        User Find(string name);
    }
}
