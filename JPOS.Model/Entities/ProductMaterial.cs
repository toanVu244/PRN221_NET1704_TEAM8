using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPOS.Model.Entities
{
    public class ProductMaterial
    {
        public int ProductMaterialID { get; set; }
        public int ProductID { get; set; }
        public int MaterialID { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public Product? Product { get; set; }
        public Material? Material { get; set; }
    }
}
