using GestorAlquiler.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorAlquiler.API.Data
{
    public class GestorAlquilerApiDbContext : DbContext
    {
        public GestorAlquilerApiDbContext(DbContextOptions<GestorAlquilerApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes => Set<Cliente>();
    }
}
