using Core.Interfaces;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public class FacturaService
    {
        private readonly IFacturaRepository _facturaRepository;

        public FacturaService(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public async Task<IEnumerable<Factura>> GetAllFacturasAsync() => await _facturaRepository.GetAll();

        public async Task<Factura> GetFacturaByIdAsync(int id) => await _facturaRepository.GetById(id);

        public async Task AddFacturaAsync(Factura factura) => await _facturaRepository.Add(factura);

        public async Task UpdateFacturaAsync(Factura factura) => await _facturaRepository.Update(factura);

        public async Task DeleteFacturaAsync(int id) => await _facturaRepository.Delete(id);
    }
}
