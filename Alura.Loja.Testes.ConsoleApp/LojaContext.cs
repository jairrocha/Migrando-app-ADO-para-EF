using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        /*
         * Não somos obrigado add a entidade 'Endereço' pois o EF faz isso
         * automaticamente devido relação 1 to 1 entre as entidades 'Cliente' e 
         * 'Endereço'. Porém o fato de não mapeamos a mesma, ficamos imposibilitados 
         * de acessar a Entidade diretamente, ou seja, para acessamos 'Endereço' teremos 
         * q acessar através da entidade 'Cliente'. (No nosso projeto não iremos
         * mapear a entidade 'Endereco'. Isso é uma decisão de arquitetura)
         */
        //public DbSet<Endereco> Enderecos { get; set; }





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


            //Definindo nome da tabela
            modelBuilder
                .Entity<Endereco>()
                .ToTable("Enderecos");

            
            /* Definindo PK da tabela endereço (a pk de 'Endereco' é igual 
             * a PK de 'Cliente' (Ou seja, 'ClienteId' em Endereco é PK e FK))
             */
            
            modelBuilder
                .Entity<Endereco>()
                .Property<int>("ClienteId");

            modelBuilder
             .Entity<Endereco>()
             .HasKey("ClienteId");
            


        }
    }
}