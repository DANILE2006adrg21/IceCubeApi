using Microsoft.EntityFrameworkCore;
using IceCube.Models;

namespace IceCube.Context
{
    public class IceCube_Apicontext : DbContext
    {
        public IceCube_Apicontext(DbContextOptions<IceCube_Apicontext> options) : base(options) { }

        public DbSet<UsuPerfil> UsuPerfil { get; set; } = default!;
        public DbSet<CatIdioma> CatIdioma { get; set; } = default!;
        public DbSet<Usuario> Usuarios { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔹 Mapeo explícito a tablas existentes para evitar errores de convención
            modelBuilder.Entity<UsuPerfil>().ToTable("UsuPerfil");
            modelBuilder.Entity<CatIdioma>().ToTable("CatIdioma");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios"); // Nota: Si en BD es "Usuario" (singular), cambiar aquí. Asumo "Usuarios" por el DbSet.
        }
    }
}
