using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IFacturaRepository
    {
        Task<IEnumerable<Factura>> GetAll();
        Task<Factura> GetById(int id);
        Task Add(Factura factura);
        Task Update(Factura factura);
        Task Delete(int id);
    }
}
