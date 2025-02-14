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
    public class VendedorRepository : IVendedorRepository
    {
        private readonly AppDbContext _context;

        public VendedorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vendedor>> GetAll() => await _context.Vendedores.ToListAsync();

        public async Task<Vendedor> GetById(int id) => await _context.Vendedores.FindAsync(id);

        public async Task Add(Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Vendedor vendedor)
        {
            _context.Vendedores.Update(vendedor);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var vendedor = await _context.Vendedores.FindAsync(id);
            if (vendedor != null)
            {
                _context.Vendedores.Remove(vendedor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
