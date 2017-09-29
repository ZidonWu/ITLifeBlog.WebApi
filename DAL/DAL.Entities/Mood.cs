using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    /// <summary>
    /// 心情类
    /// </summary>
    public class Mood : EntityBase
    {
        public Mood()
        {
            MoodComments = new List<MoodComment>();
        }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        public int? Comment { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<MoodComment> MoodComments { get; set; }

    }
}
