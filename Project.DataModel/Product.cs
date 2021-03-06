using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DataModels
{
   public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        [ForeignKey("Order")]
        public int ? OrderId { get; set; }
       
    }
}
