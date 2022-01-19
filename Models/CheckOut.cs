using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzaApplication.Models
{
  //  [Keyless]
    public class CheckOut
    {
        [Key]
        public string Name { get; set; }
        public int  MobileNumber { get; set; }
        public string Place { get; set; }
        public string city  { get; set; }
        public string Email { get; set; }
        //public int OrderID { get; set; }

    }
}
