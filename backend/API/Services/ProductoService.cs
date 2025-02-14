using Core.Interfaces;
using Core.Models;

namespace API.Services
{
    public class ProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Producto>> GetAllProductosAsync() => await _productoRepository.GetAll();

        public async Task<Producto> GetProductoByIdAsync(int id) => await _productoRepository.GetById(id);

        public async Task AddProductoAsync(Producto producto) => await _productoRepository.Add(producto);

        public async Task UpdateProductoAsync(Producto producto) => await _productoRepository.Update(producto);

        public async Task DeleteProductoAsync(int id) => await _productoRepository.Delete(id);
    }
}
