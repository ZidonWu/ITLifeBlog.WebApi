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
        public User()
        {
            Articles = new List<Article>();
        }

        public string Name { get; set; }

        public string Password { get; set; }

        public DateTime CreateTime { get; set; }

        public int RoleId { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public virtual Role Role { get; set; }
    }
}
