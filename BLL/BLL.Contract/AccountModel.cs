using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contract
{
    public class AccountModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual RoleModel RoleModel { get; set; }

    }
}
