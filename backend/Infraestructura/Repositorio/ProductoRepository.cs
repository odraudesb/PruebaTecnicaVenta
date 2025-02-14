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
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDbContext _context;

        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAll() => await _context.Productos.ToListAsync();

        public async Task<Producto> GetById(int id) => await _context.Productos.FindAsync(id);

        public async Task Add(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
