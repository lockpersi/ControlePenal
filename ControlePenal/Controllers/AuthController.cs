using ControlePenal.Application;
using ControlePenal.Context;
using ControlePenal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ControlePenal.Controllers
{
    [Route("api/CriminalApp")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private ApiContext _context;

        public AuthController(IConfiguration configuration, ApiContext context)
        {
            _config = configuration;
            _context = context;
        }

        /// <summary>
        /// Realiza o login de usuario
        /// </summary>
        /// <param name="loginUser"></param>
        /// <response code="200">Retorno Sucesso Login</response>
        /// <response code="400">Retorno Falha na tentativa de login</response>
        /// <returns>Token, expiration, id</returns>
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody]LoginModel loginUser)
        {

            var result = new LoginApp(_context).Login(loginUser);

            if (result != null)
            {
                var token = GetTokenJWT();
                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo,
                        id = result.IdUser
                    });
            }
            else
                return BadRequest("Dados inválidos");
        }

        private JwtSecurityToken GetTokenJWT()
        {
            var validIssuer = _config["JWT:ValidateIssuer"];
            var validAudience = _config["JWT:ValidateAudience"];
            var tempExpiry = DateTime.Now.AddMinutes(60);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: validIssuer, audience: validAudience, expires: tempExpiry, signingCredentials: credentials);

            return token;

        }
    }
}
