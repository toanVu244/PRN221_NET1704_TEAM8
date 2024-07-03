using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPOS.Model.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int? CategoryID { get; set; }
        public int? DesignID { get; set; }
        public string? Status { get; set; }
    }
}
