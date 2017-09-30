using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    /// <summary>
    /// 角色类
    /// </summary>
    public class Role : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
