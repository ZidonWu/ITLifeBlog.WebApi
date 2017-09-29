using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    /// <summary>
    /// BugList类
    /// </summary>
    public class BugList : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreateTime { get; set; }

    }
}
