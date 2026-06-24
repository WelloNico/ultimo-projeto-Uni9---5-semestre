using Microsoft.EntityFrameworkCore;
using Compraí____Listas_compartilhadas.Models;

namespace Compraí____Listas_compartilhadas.Data
{
    public class CompraiDbContext : DbContext
    {
        public CompraiDbContext(DbContextOptions<CompraiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<ListaBD> Listas { get; set; }

        public DbSet<ItemBD> Itens { get; set; }
    }
}