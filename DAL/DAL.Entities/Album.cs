using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    /// <summary>
    /// 相册类
    /// </summary>
    public class Album : EntityBase
    {
        public string OldFileName { get; set; }

        public string NewFileName { get; set; }

        public string Extension { get; set; }

        public string Url { get; set; }

        public string Description { get; set; } 

        public int Size { get; set; }

        public DateTime CreateTime { get; set; }

        public int UserId { get; set; }
            
        public virtual User User { get; set; }

    }
}
