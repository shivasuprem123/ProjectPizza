using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlinePizzaApplication.AppDB;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OnlinePizzaApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace OnlinePizzaApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountMangementController : ControllerBase
    {
        private readonly ApplicationDbContext _appDB;
        private UserManager<IdentityUser> _usermanager;
        private readonly IConfiguration _iconfiguration;
       // private readonly RoleManager<IdentityRole> _roleManager;

      //  private SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationSettings _appSettings;
        public AccountMangementController(IConfiguration iconfiguration,ApplicationDbContext _db, UserManager<IdentityUser> usermanager, IOptions<ApplicationSettings> appSettings)
        {
           
            _appDB = _db;
            _usermanager = usermanager;
            _appSettings = appSettings.Value;
            _iconfiguration = iconfiguration;
        }
        //webapi
        [HttpPost]
        [Route("CreateUser")]
        //Post:/api/AccountManagementController/CreateUser
        public async Task<ActionResult> CreateUser(string username, string password)
        {
            
                IdentityUser user = new IdentityUser()
                {
                    UserName = username,
                    Email = username,
                    EmailConfirmed = true
                };

            try
            {
                var result = await _usermanager.CreateAsync(user, password);
                return Ok(result);
            }catch(Exception)
            {
                return BadRequest("can not create");
            }
        }
        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            var user = await _usermanager.FindByNameAsync(model.Username);
            if (user != null && await _usermanager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _usermanager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iconfiguration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _iconfiguration["JWT:ValidIssuer"],
                    audience: _iconfiguration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    Username = user.UserName

                }) ;
            }
            return Unauthorized();
        }
       
    }
}

        
