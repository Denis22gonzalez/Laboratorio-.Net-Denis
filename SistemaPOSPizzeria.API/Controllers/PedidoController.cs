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
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoController(IPedidoRepository  pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var clientes = _pedidoRepository.PedidosList();
            return Ok(clientes);
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] Pedido model)
        {
            if (model == null)
            {
                return BadRequest("Pedido no puede ser nulo");
            }

            try
            {
                int result = _pedidoRepository.Insert(model);
                if (result > 0)
                {
                    return Ok("Pedido insertado exitosamente");
                }
                else
                {
                    return StatusCode(500, "Error al insertar el pedido");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Pedido model)
        {
            if (model == null)
            {
                return BadRequest("pedido no puede ser nulo");
            }

            try
            {
                int result = _pedidoRepository.Update(model);
                if (result > 0)
                {
                    return Ok("Pedido actualizado exitosamente");
                }
                else
                {
                    return StatusCode(500, "Error al actualizar el pedido");
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
                int result = _pedidoRepository.Delete(id);
                if (result > 0)
                {
                    return Ok("Pedido eliminado exitosamente");
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
