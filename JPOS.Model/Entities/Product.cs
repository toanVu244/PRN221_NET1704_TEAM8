using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPOS.Model.Entities
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }
        public int? PriceMaterial { get; set; }
        public int? PriceDesign { get; set; }
        public int? ProcessPrice { get; set; }
        public int? CategoryID { get; set; }
        public int? DesignID { get; set; }
        public string? Status { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public ICollection<ProductMaterial>? ProductMaterial { get; set;}
        public virtual Category? Category { get; set; }
        public virtual Design? Design { get; set; }
        public ICollection<Request>? Requests { get; set; }
    }
}
