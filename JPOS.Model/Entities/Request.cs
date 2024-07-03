using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPOS.Model.Entities
{
    public class Request
    {
        [Key]
        public int ID { get; set; }
        public string UserID { get; set; }
        public int? Type { get; set; } // 1 = Exist; 2 = Custom; 3 = New design;
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Status { get; set; } // Pending, Cancel, Approve
        public int? ProductID { get; set; }
        public string? Image { get; set; }
        public virtual User? User { get; set; }
        public virtual Product? Product { get; set; }
    }
}
