using Microsoft.AspNetCore.Authorization;
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
    public class PizzaController : ControllerBase
    {
        private readonly ApplicationDbContext _DBcon;
        public PizzaController(ApplicationDbContext cone)
        {
            _DBcon = cone;
        }
        
        [HttpGet]
        public IEnumerable<Pizza> GetPizzas()
        {
            return _DBcon.PizzaDetails.ToList();
        }
        [HttpGet]
        [Route("name")]
        public Pizza GetById(string name)
        {
            return _DBcon.PizzaDetails.Where(x => x.PizzaName == name).FirstOrDefault();
        }
        [HttpPost]
        public async Task<Pizza> Create(Pizza _object)
        {
            
                var obj = await _DBcon.PizzaDetails.AddAsync(_object);
                _DBcon.SaveChanges();
                return obj.Entity;   
        }
        

    }
}
