using Core.Interfaces;
using Core.Models;

namespace API.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync() => await _clienteRepository.GetAll();

        public async Task<Cliente> GetClienteByIdAsync(int id) => await _clienteRepository.GetById(id);

        public async Task AddClienteAsync(Cliente cliente) => await _clienteRepository.Add(cliente);

        public async Task UpdateClienteAsync(Cliente cliente) => await _clienteRepository.Update(cliente);

        public async Task DeleteClienteAsync(int id) => await _clienteRepository.Delete(id);
    }
}
