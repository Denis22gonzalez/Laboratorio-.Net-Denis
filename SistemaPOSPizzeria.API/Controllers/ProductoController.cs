using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPOSPizzeria.DataAccess.Interfaces;
using SistemaPOSPizzeria.DataAccess.Models;
using SistemaPOSPizzeria.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPOSPizzeria.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;
        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var clientes = _productoRepository.ProductosList();
            return Ok(clientes);
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] Producto model)
        {
            if (model == null)
            {
                return BadRequest("Producto no puede ser nulo");
            }

            try
            {
                int result = _productoRepository.Insert(model);
                if (result > 0)
                {
                    return Ok("Producto insertado exitosamente");
                }
                else
                {
                    return StatusCode(500, "Error al insertar el producto");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Producto model)
        {
            if (model == null)
            {
                return BadRequest("producto no puede ser nulo");
            }

            try
            {
                int result = _productoRepository.Update(model);
                if (result > 0)
                {
                    return Ok("Producto actualizado exitosamente");
                }
                else
                {
                    return StatusCode(500, "Error al actualizar el producto");
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
                int result = _productoRepository.Delete(id);
                if (result > 0)
                {
                    return Ok("Producto eliminado exitosamente");
                }
                else
                {
                    return StatusCode(500, "Error al eliminar el producto");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
