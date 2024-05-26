using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPOSPizzeria.DataAccess.Interfaces;
using SistemaPOSPizzeria.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPOSPizzeria.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ClienteDireccionController : ControllerBase
    {
        private readonly IClienteDireccionRepository _clienteDireccionRepository;
        public ClienteDireccionController(IClienteDireccionRepository clienteDireccionRepository)
        {
            _clienteDireccionRepository = clienteDireccionRepository;
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            var clientes = _clienteDireccionRepository.DireccionesList(id);
            return Ok(clientes);
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] Direccion model)
        {
            if (model == null)
            {
                return BadRequest("Direccion no puede ser nulo");
            }

            try
            {
                int result = _clienteDireccionRepository.Insert(model);
                if (result > 0)
                {
                    return Ok("Direccion insertada exitosamente");
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

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Direccion model)
        {
            if (model == null)
            {
                return BadRequest("Direccion no puede ser nulo");
            }

            try
            {
                int result = _clienteDireccionRepository.Update(model);
                if (result > 0)
                {
                    return Ok("Direccion actualizada exitosamente");
                }
                else
                {
                    return StatusCode(500, "Error al insertar la direccion");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {

            try
            {
                int result = _clienteDireccionRepository.Delete(id);
                if (result > 0)
                {
                    return Ok("Direccion eliminado exitosamente");
                }
                else
                {
                    return StatusCode(500, "Error al eliminar Direccion");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
