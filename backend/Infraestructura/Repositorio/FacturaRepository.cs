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
    public class FacturaRepository : IFacturaRepository
    {
        private readonly AppDbContext _context;

        public FacturaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Factura>> GetAll() => await _context.Facturas.Include(f => f.Cliente).Include(f => f.Vendedor).ToListAsync();

        public async Task<Factura> GetById(int id) => await _context.Facturas.Include(f => f.Cliente).Include(f => f.Vendedor).FirstOrDefaultAsync(f => f.FacturaId == id);

        public async Task Add(Factura factura)
        {
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Factura factura)
        {
            _context.Facturas.Update(factura);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            if (factura != null)
            {
                _context.Facturas.Remove(factura);
                await _context.SaveChangesAsync();
            }
        }
    }
}
