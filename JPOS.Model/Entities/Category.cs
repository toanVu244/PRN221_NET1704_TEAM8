using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPOS.Model.Entities
{
    public class Category
    {
        [Key]
        public int CatID { get; set; }
        public string? CatName { get; set; }
        public string? Description { get; set; }
    }
}
