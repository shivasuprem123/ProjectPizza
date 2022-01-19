using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzaApplication.Models
{
    public class Review
    {
       
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int rating { get; set; }
        public int pizzaid { get; set; }
        public string username { get; set; }
    }
}
