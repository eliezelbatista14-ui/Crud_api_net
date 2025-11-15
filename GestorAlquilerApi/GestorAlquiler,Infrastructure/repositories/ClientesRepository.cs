using GestorAlquiler.Domain.Entities;
using GestorAlquiler.Domain.Interfaces;
using GestorAlquiler.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GestorAlquiler.Infrastructure.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly GestorAlquilerDbContext _context;

        public ClienteRepository(GestorAlquilerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
            => await _context.Clientes.ToListAsync();

        public async Task<Cliente?> GetByIdAsync(int id)
            => await _context.Clientes.FindAsync(id);

        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var c = await _context.Clientes.FindAsync(id);
            if (c != null)
            {
                _context.Clientes.Remove(c);
                await _context.SaveChangesAsync();
            }
        }
    }
}
