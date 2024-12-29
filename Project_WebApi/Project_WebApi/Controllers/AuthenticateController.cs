using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project_WebApi.IRepo;
using Project_WebApi.Models;
using Project_WebApi.ViewModels;

namespace Project_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        IAuthenticateRepository _repo;
        IConfiguration _config;

        //public AuthenticateController() { }
        public AuthenticateController(IAuthenticateRepository repo, IConfiguration configuration)
        {
            _repo = repo;
            _config = configuration;
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            IActionResult response = Unauthorized();

            var user = _repo.AuthenticateUser(loginViewModel);
            if (user != null)
            {

                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });


            }

            return response;


        }

        //private string GenerateJSONWebToken(User user)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        //      _config["Jwt:Audience"],
        //      null,
        //      expires: DateTime.Now.AddMinutes(120),
        //      signingCredentials: credentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        private string GenerateJSONWebToken(User user)
        {
            string rolName = _repo.GetRoleName(user.RoleId);

            List<Role> roles = new List<Role>();
            roles = _repo.GetAllRoles();
            List<Claim> claims = new List<Claim> {

                 new Claim("UserName", user.UserName),
                 new Claim("Role",rolName.ToString()),
                 new Claim(type:"Date", DateTime.Now.ToString())
            };

            foreach (var temp in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, temp.RoleName));
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
