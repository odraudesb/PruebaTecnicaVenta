using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> GetById(int id);
        Task Add(Cliente cliente);
        Task Update(Cliente cliente);
        Task Delete(int id);
    }
}
