using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlinePizzaApplication.AppDB;
using OnlinePizzaApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzaApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ApplicationDbContext _DBcon;
        public CartController(ApplicationDbContext cone)
        {
            _DBcon = cone;
        }
        //int32 int.string
        [HttpGet]
        public IEnumerable<Cart> GetCart()
        {
            return _DBcon.Cart.ToList();
        }
        [HttpPost]
        public async Task<Cart> Create(Cart _object)
        {
            var obj = await _DBcon.Cart.AddAsync(_object);
            _DBcon.SaveChanges();
            return obj.Entity;
        }

    }
}
