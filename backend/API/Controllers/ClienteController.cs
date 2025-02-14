using API.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        private readonly ILogger<ClienteController> _logger;
        public ClienteController(ClienteService clienteService, ILogger<ClienteController> logger)
        {
            _clienteService = clienteService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
        {
            try
            {
                return Ok(await _clienteService.GetAllClientesAsync());
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al consultar los clientes.");
                return StatusCode(500, $"Error al consular los clientes: {ex.Message}");
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            try
            {
                var cliente = await _clienteService.GetClienteByIdAsync(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el cliente.");
                return StatusCode(500, $"Error al obtener el cliente: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Cliente cliente)
        {
            try
            {

                await _clienteService.AddClienteAsync(cliente);
                return CreatedAtAction(nameof(GetById), new { id = cliente.ClienteId }, cliente);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al crear el cliente.");
                return StatusCode(500, $"Error al crear el cliente: {ex.Message}");
            }


        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Cliente cliente)
        {
            try
            {
                if (id != cliente.ClienteId)
                    return BadRequest();

                await _clienteService.UpdateClienteAsync(cliente);
                return NoContent();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al actualizar el cliente.");
                return StatusCode(500, $"Error al actualizar el cliente: {ex.Message}");
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {


                await _clienteService.DeleteClienteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el cliente.");
                return StatusCode(500, $"Error al eliminar el cliente: {ex.Message}");

            }

        }
    }
}
