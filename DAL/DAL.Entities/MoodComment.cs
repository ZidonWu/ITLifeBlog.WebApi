using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    /// <summary>
    /// 心情评论类
    /// </summary>
    public class MoodComment : EntityBase
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        public int MoodId { get; set; }

        public virtual Mood Mood { get; set; }

    }
}
