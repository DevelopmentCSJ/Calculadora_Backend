using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Calculadora.Api.Data;

public partial class CalculadoraContext : DbContext
{
    public CalculadoraContext()
    {
    }

    public CalculadoraContext(DbContextOptions<CalculadoraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Planta> Plantas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SV01003-UDAPP01;Initial Catalog=calculadora;Integrated Security=True;MultipleActiveResultSets=False;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Planta>(entity =>
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
