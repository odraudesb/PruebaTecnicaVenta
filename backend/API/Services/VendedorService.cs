using Core.Interfaces;
using Core.Models;

namespace API.Services
{
    public class VendedorService
    {
        private readonly IVendedorRepository _vendedorRepository;

        public VendedorService(IVendedorRepository vendedorRepository)
        {
            _vendedorRepository = vendedorRepository;
        }

        public async Task<IEnumerable<Vendedor>> GetAllVendedoresAsync() => await _vendedorRepository.GetAll();

        public async Task<Vendedor> GetVendedorByIdAsync(int id) => await _vendedorRepository.GetById(id);

        public async Task AddVendedorAsync(Vendedor producto) => await _vendedorRepository.Add(producto);

        public async Task UpdateVendedorAsync(Vendedor producto) => await _vendedorRepository.Update(producto);

        public async Task DeleteVendedorAsync(int id) => await _vendedorRepository.Delete(id);
    }
}
