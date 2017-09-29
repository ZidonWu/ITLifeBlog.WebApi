using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    /// <summary>
    /// 文章类
    /// </summary>
    public class Article : EntityBase
    {
        public Article()
        {
            ArticleComments = new List<ArticleComment>();
        }

        public string ArticleGuid { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public int? Stars { get; set; }

        public int? ReadNum { get; set; }

        public int? CommentNum { get; set; }

        public bool? IsPublish { get; set; }

        public bool IsDelete { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public virtual User User { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<ArticleComment> ArticleComments { get; set; }

    }
}
