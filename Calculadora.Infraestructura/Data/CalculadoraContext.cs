using Calculadora.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Infraestructura.Data
{
    public class CalculadoraContext : DbContext
    {
        public CalculadoraContext()
        {

        }

        public CalculadoraContext(DbContextOptions<CalculadoraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Plantas> Plantas { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlServer("Server=SV01003-UDAPP01;Initial Catalog=calculadora;Integrated Security=True;MultipleActiveResultSets=False;Trusted_Connection=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plantas>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("plantas");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");
                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

        }
    }
}
