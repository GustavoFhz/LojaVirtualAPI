using LojaVirtual.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoriaModel>()
            .HasMany(c => c.Produtos)
            .WithOne(p => p.Categoria)
            .HasForeignKey(p => p.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CategoriaModel>().HasData(
            new CategoriaModel { Id = 1, Nome = "Alimentos e bebidas" },
            new CategoriaModel { Id = 2, Nome = "Eletrônicos" },
            new CategoriaModel { Id = 3, Nome = "Roupas e Acessórios" },
            new CategoriaModel { Id = 4, Nome = "Beleza e Cuidados Pessoais" }
    );

        }

    }
}
