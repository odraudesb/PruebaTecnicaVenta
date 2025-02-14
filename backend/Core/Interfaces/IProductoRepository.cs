using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAll();
        Task<Producto> GetById(int id);
        Task Add(Producto producto);
        Task Update(Producto producto);
        Task Delete(int id);
    }
}
