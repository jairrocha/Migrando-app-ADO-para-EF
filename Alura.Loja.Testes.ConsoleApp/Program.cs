using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {

        /* Preparando o ambiente:
         * 
         * Aviso: Criar o BD: LojaDB e criar a tabela (script da tabela no arquivo: ddl-produtos.txt)
         * PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 1.1
         * 
         */

        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            RecuperarProdutos();
            GravarUsandoEntity();
            AtualizarProduto();
            ExcluirProdutos();
         
            

        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var contexto = new ProdutoDAOEntity())
            {
               
                contexto.Adicionar(p);

            }

            //Exibe produtos
            RecuperarProdutos();
        }

        private static void AtualizarProduto()
        {
            //Exibir antes da alteração
            RecuperarProdutos();

            using (var repo = new ProdutoDAOEntity())
            {
                Produto produto = repo.Produtos().First();
                produto.Nome = "Matrix";
                repo.Atualizar(produto);
            }

            //Exibir após alteração
            RecuperarProdutos();
        }

        private static void ExcluirProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = repo.Produtos();

                foreach (var produto in produtos)
                {
                    repo.Remover(produto);
                }

            }

            //Exibe produtos
            RecuperarProdutos();
        }

        private static void RecuperarProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = repo.Produtos();

                Console.WriteLine("Foram encontrados {0} produto(s).", produtos.Count) ;

                foreach (var produto in produtos)
                {
                    Console.WriteLine(produto.Nome);
                }
            }

        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }

            
        }
    }
}
