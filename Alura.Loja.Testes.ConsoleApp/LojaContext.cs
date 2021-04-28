using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");

        }

        /* Podemos através da sobrescrita do método OnModelCreating
         * definir como nossas entidades serão criadas
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Definindo PK (Chave composta: ProdutoId+PromocaoId ) de PromocaoProduto.
            modelBuilder
                .Entity<PromocaoProduto>()
                .HasKey(pp => new { pp.ProdutoId, pp.PromocaoId});

            base.OnModelCreating(modelBuilder); 
        }
    }
}