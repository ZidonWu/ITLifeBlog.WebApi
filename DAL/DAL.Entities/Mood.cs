﻿using Newtonsoft.Json;
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
        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        public int Comment { get; set; }

        public int AccountId { get; set; }

        public virtual Account Account { get; set; }

        public virtual ICollection<MoodComment> MoodComment { get; set; }   
    }
}
