﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    /// <summary>
    /// 栏目类
    /// </summary>
    public class Category :EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }

        public int Count { get; set; }

        //public virtual ICollection<Article> Article { get; set; }   
    }
}
