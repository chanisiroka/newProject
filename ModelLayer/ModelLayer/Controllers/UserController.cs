using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using securityLessonWebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ModelLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration config;
        public UserController(IConfiguration config)
        {
            this.config = config;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost("{username}/{password}")]
        public IActionResult Post(string username,string password)
        {
            var user = Authenticate(username,password);
            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }
            return BadRequest("user not found");
        }
        private string Generate(UserModel user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier,user.UserName),
            new Claim(ClaimTypes.Email,user.Mail),
            new Claim(ClaimTypes.Surname,user.SurName),
            new Claim(ClaimTypes.Role,user.Role),
            new Claim(ClaimTypes.GivenName,user.GivenName)
            
            };
            var token = new JwtSecurityToken(config["Jwt:Issuer"], config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        //אימות משתמש
        private UserModel Authenticate(string user,string pass)
        {
            var user1 = UserContacts.Db.FirstOrDefault(x => x.Password == pass && x.UserName == user);
            if (user1 != null)
                return user1;
            return null;
        }
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
