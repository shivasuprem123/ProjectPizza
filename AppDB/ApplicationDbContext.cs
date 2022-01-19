using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlinePizzaApplication.Models;

namespace OnlinePizzaApplication.AppDB
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        internal Task FindByNameAsync(string username)
        {
            throw new NotImplementedException();
        }
        public virtual DbSet<Pizza> PizzaDetails { get; set; }
        public virtual DbSet<category> CategoryDetails { get; set; }

        public virtual DbSet<CheckOut> CheckOut { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }

       
        public virtual DbSet<Review> reviews { get; set; }

    }
}
