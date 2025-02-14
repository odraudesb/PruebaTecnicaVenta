using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorio
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAll() => await _context.Clientes.ToListAsync();

        public async Task<Cliente> GetById(int id) => await _context.Clientes.FindAsync(id);

        public async Task Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }

}
