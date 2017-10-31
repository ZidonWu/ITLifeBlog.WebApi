using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BLL.Contract
{
    public class ArticleModel
    {
        public int Id { get; set; }

        public string ArticleGuid { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsPublish { get; set; }

        public bool IsDeleted { get; set; }

        public int AccountId { get; set; }

        public int CategoryId { get; set; } 

        public virtual AccountModel AccountModel { get; set; }

        public virtual CategoryModel CategoryModel { get; set; }    
    }
}
