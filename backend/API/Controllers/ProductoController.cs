using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using API.Services;
using Core.Models;
using Serilog;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productoService;
        private readonly ILogger<ProductoController> _logger;
        public ProductoController(ProductoService productoService, ILogger<ProductoController> logger)
        {
            _productoService = productoService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetAll()
        {
            try
            {
                return Ok(await _productoService.GetAllProductosAsync());
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al consultar los productos.");
                return StatusCode(500, $"Error al consultar los productos: {ex.Message}");
            }  
         
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetById(int id)
        {
            try
            {
                var producto = await _productoService.GetProductoByIdAsync(id);
                if (producto == null)
                {
                    return NotFound();
                }
                return Ok(producto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el producto.");
                return StatusCode(500, $"Error al obtener el producto: {ex.Message}");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Producto producto)
        {
            try
            {

                if (producto == null) return BadRequest();

                await _productoService.AddProductoAsync(producto);
                return CreatedAtAction(nameof(GetById), new { id = producto.ProductoId }, producto);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al crear el producto.");
                return StatusCode(500, $"Error al crear el producto: {ex.Message}");
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Producto producto)
        {
            try
            {
                if (id != producto.ProductoId) return BadRequest();

                await _productoService.UpdateProductoAsync(producto);
                return NoContent();
            }
            catch(Exception ex)
            {

                _logger.LogError(ex, "Error al actualizar el producto.");
                return StatusCode(500, $"Error al actualizar el producto: {ex.Message}");
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                await _productoService.DeleteProductoAsync(id);
                return NoContent();
            }
          catch( Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el producto.");
                return StatusCode(500, $"Error al eliminar el producto: {ex.Message}");

            }
        }
    }
}
