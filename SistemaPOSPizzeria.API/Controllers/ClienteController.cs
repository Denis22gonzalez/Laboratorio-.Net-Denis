using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaPOSPizzeria.DataAccess.Interfaces;
using SistemaPOSPizzeria.DataAccess.Repositories;
using SistemaPOSPizzeria.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;

namespace SistemaPOSPizzeria.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
       //GET: api/<ClienteController>
        [HttpGet]
        public IActionResult Get()
        {
            var clientes =_clienteRepository.ClientesList();
            return  Ok(clientes);
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] Cliente model)
        {
            if (model == null)
            {
                return BadRequest("Cliente no puede ser nulo");
            }

            try
            {
                int result = _clienteRepository.Insert(model);
                if (result > 0)
                {
                    return Ok("Cliente insertado exitosamente");
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
        public IActionResult Update([FromBody] Cliente model)
        {
            if (model == null)
            {
                return BadRequest("Cliente no puede ser nulo");
            }

            try
            {
                int result = _clienteRepository.Update(model);
                if (result > 0)
                {
                    return Ok("Cliente actualizado exitosamente");
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

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {

            try
            {
                int result = _clienteRepository.Delete(id);
                if (result > 0)
                {
                    return Ok("Cliente eliminado exitosamente");
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

    }
}
