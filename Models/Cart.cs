using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzaApplication.Models
{
   
    public class Cart
    {
        [Key]
        public int Sno { get; set; }
        public string ItemName { get; set; }
        public int Price { get; set; }
       

    }
}
