using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    /// <summary>
    /// 留言类
    /// </summary>
    public class Message : EntityBase
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

    }
}
