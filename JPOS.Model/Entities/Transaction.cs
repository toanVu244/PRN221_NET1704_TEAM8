using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPOS.Model.Entities
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        public string? RequestID { get; set; }
        public string UserID { get; set; }
        public string? Description {get;set; }
        public DateTime? CreatedDate { get; set; }
        public virtual User User { get; set; }
    }
}
