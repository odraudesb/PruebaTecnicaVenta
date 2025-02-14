using API.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly VendedorService _vendedorService;
        private readonly ILogger<VendedorController> _logger;
        public VendedorController(VendedorService vendedorService, ILogger<VendedorController> logger)
        {
            _vendedorService = vendedorService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendedor>>> GetAll()
        {
            try
            {
                return Ok(await _vendedorService.GetAllVendedoresAsync());
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al consultar los vendedores.");
                return StatusCode(500, $"Error al consultar los vendedores: {ex.Message}");
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vendedor>> GetById(int id)
        {
            try
            {
                var factura = await _vendedorService.GetVendedorByIdAsync(id);
                if (factura == null)
                    return NotFound();

                return Ok(factura);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el vendedor.");
                return StatusCode(500, $"Error al obtener el vendedor: {ex.Message}");
            }

       
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Vendedor vendedor)
        {
            try
            {

                if (vendedor== null) return BadRequest();

                await _vendedorService.AddVendedorAsync(vendedor);
                return CreatedAtAction(nameof(GetById), new { id = vendedor.VendedorId }, vendedor);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al crear el vendedor.");
                return StatusCode(500, $"Error al crear el vendedor: {ex.Message}");
            }


       }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Vendedor vendedor)
        {
            try
            {

                if (id != vendedor.VendedorId)
                    return BadRequest();

                await _vendedorService.UpdateVendedorAsync(vendedor);
                return NoContent();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al actualizar el vendedor.");
                return StatusCode(500, $"Error al actualizar el vendedor: {ex.Message}");
            }


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                await _vendedorService.DeleteVendedorAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el vendedor.");
                return StatusCode(500, $"Error al eliminar el vendedor: {ex.Message}");

            }

        }
    }
}
