using Microsoft.EntityFrameworkCore;
using IceCube.Models;

namespace IceCube.Context
{
    public class IceCube_Apicontext : DbContext
    {
        public IceCube_Apicontext(DbContextOptions<IceCube_Apicontext> options) : base(options) { }

        // Tablas
        public DbSet<UsuPerfil> UsuPerfil { get; set; } = default!;
        public DbSet<CatIdioma> CatIdioma { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // === Tabla CatIdioma ===
            modelBuilder.Entity<CatIdioma>(entity =>
            {
                entity.ToTable("    ");
                entity.HasKey(e => e.id);
                entity.Property(e => e.strValor)
                      .HasMaxLength(50)
                      .IsRequired(false);
            });


            // === Tabla UsuPerfil ===
            modelBuilder.Entity<UsuPerfil>(entity =>
            {
                entity.ToTable("UsuPerfil");
                entity.HasKey(e => e.id);

                entity.Property(e => e.strNombreUsuario)
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(e => e.strGenero)
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(e => e.dtFechaNacimiento)
                      .HasColumnType("date");

                entity.Property(e => e.strDescripcion)
                      .HasMaxLength(300)
                      .IsRequired();

                entity.Property(e => e.strFotoPerfil)
                      .HasMaxLength(250)
                      .IsRequired();

                entity.Property(e => e.strCiudad)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.strPais)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.strPreferenciaGenero)
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(e => e.idCatIdioma)
                      .IsRequired();

                entity.Property(e => e.strOcupacion)
                      .HasMaxLength(100)
                      .IsRequired(false);

                entity.Property(e => e.strEscuelaEmpresa)
                      .HasMaxLength(150)
                      .IsRequired(false);

                entity.Property(e => e.strObjetivo)
                      .HasMaxLength(300)
                      .IsRequired(false);

                entity.Property(e => e.strSituaciones)
                      .HasMaxLength(300)
                      .IsRequired(false);

                entity.Property(e => e.strIntereses)
                      .HasMaxLength(300)
                      .IsRequired(false);


                // Relación FK con CatIdioma
                entity.HasOne(e => e.CatIdioma)
                      .WithMany()
                      .HasForeignKey(e => e.idCatIdioma)
                      .OnDelete(DeleteBehavior.Restrict);
            });



        }
    }
}
