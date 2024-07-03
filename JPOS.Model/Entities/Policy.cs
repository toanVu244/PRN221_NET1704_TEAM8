using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPOS.Model.Entities
{
    public class Policy
    {
        public int PolicyID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public virtual User User { get; set; }  
    }
}
