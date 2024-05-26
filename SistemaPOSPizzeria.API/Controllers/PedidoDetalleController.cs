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
    public class PedidoDetalleController : ControllerBase
    {
        private readonly IPedidoDetalleRepository _pedidoDetalleRepository;
        public PedidoDetalleController(IPedidoDetalleRepository pedidoDetalleRepository)
        {
            _pedidoDetalleRepository = pedidoDetalleRepository;
        }

        [HttpGet]
        public IActionResult Get(int idpedido)
        {
            var clientes = _pedidoDetalleRepository.PedidosDetallesList(idpedido);
            return Ok(clientes);
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] CabeceraDetalle model)
        {
            if (model == null)
            {
                return BadRequest("Pedido detalle no puede ser nulo");
            }

            try
            {
                int result = _pedidoDetalleRepository.Insert(model);
                if (result > 0)
                {
                    return Ok("Pedido detalle insertado exitosamente");
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
        public IActionResult Update([FromBody] CabeceraDetalle model)
        {
            if (model == null)
            {
                return BadRequest("pedido no puede ser nulo");
            }

            try
            {
                int result = _pedidoDetalleRepository.Update(model);
                if (result > 0)
                {
                    return Ok("Pedido detalle actualizado exitosamente");
                }
                else
                {
                    return StatusCode(500, "Error al actualizar el pedido detalle");
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
                int result = _pedidoDetalleRepository.Delete(id);
                if (result > 0)
                {
                    return Ok("Pedido detalle eliminado exitosamente");
                }
                else
                {
                    return StatusCode(500, "Error al eliminar pedido detalle");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
