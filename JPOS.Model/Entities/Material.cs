﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPOS.Model.Entities
{
        public class Material
        {
            [Key]
            public int MaterialID { get; set; }
            public string? Name { get; set; }
            public int? Price { get; set; }
            public int? Quantity { get; set; }
            public int? TotalPrice { get; set; }
            public string? Status { get; set; }
            public ICollection<ProductMaterial>? ProductMaterial { get; set; }
        }
}
