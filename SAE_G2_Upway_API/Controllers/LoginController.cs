using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SAE_G2_Upway_API.Models;
using SAE_G2_Upway_API.Models.EntityFramework;
using SAE_G2_Upway_API.Models.Repository;

namespace SAE_G2_Upway_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IDataRepository<Client, Client> dataRepository;
        private List<Client>? appUsers;

        public LoginController(IConfiguration config, IDataRepository<Client, Client> dataRepo)
        {
            _config = config;
            dataRepository = dataRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetClients()
        {
            var action_result = await dataRepository.GetAllAsync();
            appUsers = action_result.Value.ToList();
            if (appUsers == null || appUsers.Count == 0) 
            {
                return BadRequest();
            }
            return Ok(appUsers);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string mail, string password)
        {
            var osef = GetClients().Result;
            IActionResult response = Unauthorized();
            Client user = AuthenticateUser(mail, password);
            if (user != null)
            {
                var tokenString = GenerateJwtToken(user);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = user,
                });
            }
            return response;
        }
        private Client AuthenticateUser(string mail, string password)
        {
            return appUsers.SingleOrDefault(x => x.Mailclient.ToUpper() == mail.ToUpper() && BCrypt.Net.BCrypt.EnhancedVerify(password, x.Password));
        }
        private string GenerateJwtToken(Client userInfo)
        {
            var securityKey = new
            SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Mailclient),
                new Claim("fullName", userInfo.Prenomclient.ToString() + " " + userInfo.Nomclient.ToString()),
                new Claim("role",userInfo.UserRole),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
