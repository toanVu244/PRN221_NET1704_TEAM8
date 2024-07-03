using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPOS.Model.Entities
{
    public class Design
    {
        [Key]
        public int DesignID { get; set; }
        public string? CreateBy { get; set; }
        public string? Picture { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }

    }
}
