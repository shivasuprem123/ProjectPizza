using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzaApplication.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaID { get; set; }
        public string PizzaName { get; set; }
        public int Price { get; set; }
        public string Discription { get; set; }
        public int Categoryid{ get; set; }
    }
}
