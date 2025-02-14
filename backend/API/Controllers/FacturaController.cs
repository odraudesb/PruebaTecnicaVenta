using API.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaService _facturaService;

        private readonly ILogger<FacturaController> _logger;
        public FacturaController(FacturaService facturaService, ILogger<FacturaController> logger)
        {
            _facturaService = facturaService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factura>>> GetAll()
        {

            try
            {
                return Ok(await _facturaService.GetAllFacturasAsync());
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al consultar los facturas.");
                return StatusCode(500, $"Error al consultar los facturas: {ex.Message}");
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Factura>> GetById(int id)
        {

            try
            {

                var factura = await _facturaService.GetFacturaByIdAsync(id);
                if (factura == null)
                    return NotFound();

                return Ok(factura);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el factura.");
                return StatusCode(500, $"Error al obtener el factura: {ex.Message}");
            }


        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Factura factura)
        {
            try
            {

                if (factura == null) return BadRequest();

                await _facturaService.AddFacturaAsync(factura);
                return CreatedAtAction(nameof(GetById), new { id = factura.FacturaId }, factura);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al crear el factura.");
                return StatusCode(500, $"Error al crear el factura: {ex.Message}");
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Factura factura)
        {
            try
            {
                if (id != factura.FacturaId)
                    return BadRequest();

                await _facturaService.UpdateFacturaAsync(factura);
                return NoContent();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al actualizar el factura.");
                return StatusCode(500, $"Error al actualizar el factura: {ex.Message}");
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _facturaService.DeleteFacturaAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el factura.");
                return StatusCode(500, $"Error al eliminar el factura: {ex.Message}");

            }

        }
    }
}
