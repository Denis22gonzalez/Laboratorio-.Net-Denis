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
using SistemaPOSPizzeria.DataAccess.Models;
using SistemaPOSPizzeria.DataAccess.Interfaces;

namespace SistemaPOSPizzeria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly string KeySecret;
        private readonly IUsuarioRepository _UsuarioRepository;

        public AuthenticationController(IConfiguration config, IUsuarioRepository UsuarioRepository)
        {
            KeySecret=config.GetSection("settings").GetSection("secretKey").ToString();
            _UsuarioRepository = UsuarioRepository;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult ValidateIdentity([FromBody] Usuario model)
        {
            try
            {
                var result = _UsuarioRepository.Login(model);
                //1 es otorgado
                if (result.Code==1)
                {
                    var keyBytes = Encoding.ASCII.GetBytes(KeySecret);
                    var claims = new ClaimsIdentity();
                    claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, model.UsuarioNombre));
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

                //    {
                //        return BadRequest("Usuario no puede ser nulo");
                //    }
                

                else
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
                }
            }
            catch (Exception e)
            {

                throw;
            }
            
        }
        [HttpPost]
        [Route("Registrar")]
        public IActionResult Insert([FromBody] Usuario model)
        {
            if (model == null)
            {
                return BadRequest("Usuario no puede ser nulo");
            }

            try
            {
                int result = _UsuarioRepository.Insert(model);
                if (result > 0)
                {
                    return Ok("Usuario insertado exitosamente");
                }
                else
                {
                    return StatusCode(500, "Error al insertar el cliente");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
        //[HttpPost]
        //[Route("Login")]
        //public IActionResult Login([FromBody] Usuario model)
        //{
        //    if (model == null)
        //    {
        //        return BadRequest("Usuario no puede ser nulo");
        //    }

        //    try
        //    {
        //        int result = _UsuarioRepository.Login(model);
        //        if (result > 0)
        //        {
        //            return Ok("Usuario logeado exitosamente");
        //        }
        //        else
        //        {
        //            return StatusCode(500, "Error al insertar el cliente");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Error: {ex.Message}");
        //    }
        //}
    }
}
