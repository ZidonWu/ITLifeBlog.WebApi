using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class User : EntityBase
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public DateTime CreateTime { get; set; }

        public virtual Role Role { get; set; }
    }
}
