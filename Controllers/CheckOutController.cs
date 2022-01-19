using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlinePizzaApplication.AppDB;
using OnlinePizzaApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnlinePizzaApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckOutController : ControllerBase
    {
        private readonly ApplicationDbContext _DBcon;
        public CheckOutController(ApplicationDbContext cone)
        {
            _DBcon = cone;
        }
        [HttpGet]
        public IEnumerable<CheckOut> GetOrders()
        {
            return _DBcon.CheckOut.ToList();
        }
        [HttpPost]
        public async Task<CheckOut> Create(CheckOut _object)
        {
            
                var obj = await _DBcon.CheckOut.AddAsync(_object);
                _DBcon.SaveChanges();
                return obj.Entity;
       
        }

    }
}
