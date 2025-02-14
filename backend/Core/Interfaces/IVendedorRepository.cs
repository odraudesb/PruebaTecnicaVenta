using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IVendedorRepository
    {
        Task<IEnumerable<Vendedor>> GetAll();
        Task<Vendedor> GetById(int id);
        Task Add(Vendedor vendedor);
        Task Update(Vendedor vendedor);
        Task Delete(int id);
    }
}
