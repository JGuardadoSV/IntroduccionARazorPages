using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication1.Entidades
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options) { }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación explícita 1:N
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Datos semilla
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "Electrónica", Descripcion = "Gadgets y dispositivos" },
                new Categoria { Id = 2, Nombre = "Ropa", Descripcion = "Prendas de vestir" },
                new Categoria { Id = 3, Nombre = "Alimentación", Descripcion = "Productos alimenticios" }
            );

            modelBuilder.Entity<Producto>().HasData(
                new Producto { Id = 1, Nombre = "Laptop HP", Precio = 12500m, Stock = 15, CategoriaId = 1 },
                new Producto { Id = 2, Nombre = "Audífonos", Precio = 499.99m, Stock = 40, CategoriaId = 1 },
                new Producto { Id = 3, Nombre = "Camiseta XL", Precio = 199m, Stock = 100, CategoriaId = 2 }
            );
        }


    }
}
