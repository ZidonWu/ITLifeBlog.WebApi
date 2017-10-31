using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    /// <summary>
    /// 文章评论类
    /// </summary>
    public class ArticleComment : EntityBase
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
