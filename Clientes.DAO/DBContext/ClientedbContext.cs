using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Clientes.DAO.DBContext;

public partial class ClientedbContext : DbContext
{
    public ClientedbContext()
    {
    }

    public ClientedbContext(DbContextOptions<ClientedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-AVAJEQHO\\SQLEXPRESS01; DataBase=CLIENTEDB;Integrated Security=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Cliente");

            entity.Property(e => e.Apellidos)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Cuit)
                .IsUnicode(false)
                .HasColumnName("cuit");
            entity.Property(e => e.Domicilio)
                .IsUnicode(false)
                .HasColumnName("domicilio");
            entity.Property(e => e.Email)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaDeNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fecha_de_nacimiento");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Nombres)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.TelefonoCelular)
                .IsUnicode(false)
                .HasColumnName("telefono_celular");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
