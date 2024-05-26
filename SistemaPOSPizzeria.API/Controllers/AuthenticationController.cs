using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaPOSPizzeria.Api.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SistemaPOSPizzeria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly string KeySecret;

        public AuthenticationController(IConfiguration config)
        {
            KeySecret=config.GetSection("settings").GetSection("secretKey").ToString();
        }

        [HttpPost]
        [Route("Validate")]
        public IActionResult ValidateIdentity([FromBody] User user)
        {
            if (user.Nombre == "Denis" && user.Password == "hola123")
            {
                var keyBytes = Encoding.ASCII.GetBytes(KeySecret);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Nombre));
                var tokenDes = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenconfig = tokenHandler.CreateToken(tokenDes);

                var tokencreated = tokenHandler.WriteToken(tokenconfig);

                return StatusCode(StatusCodes.Status200OK, new { token = tokencreated });
            }

            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token ="" });
            }
        }
    }
}
