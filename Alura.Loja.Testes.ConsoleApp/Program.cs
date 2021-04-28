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
         * Aviso: Remover tabela Produtos e aplicar as migrações
         * PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 1.1
         * PM> Install-Package Microsoft.EntityFrameworkCore.Tools -Version 1.1.1
         * 
         */

        /* Dicas:
         * PM> Get-Help Entity (Exibe comandos que pode ser utilizados no EF)
         * 
         */



        static void Main(string[] args)
        {

            var p1 = new Produto()
            {
                Nome = "Suco de laranja",
                Categoria = "Bebidas",
                PrecoUnitario = 8.79,
                Unidade = "Litros"
            };
            var p2 = new Produto()
            {
                Nome = "Café",
                Categoria = "Bebidas",
                PrecoUnitario = 12.45,
                Unidade = "Gramas"
            };
            var p3 = new Produto()
            {
                Nome = "Macarrão",
                Categoria = "Alimentos",
                PrecoUnitario = 4.23,
                Unidade = "Gramas"
            };

            var promocao = new Promocao();
            promocao.Descricao = "Pascoa Feliz";
            promocao.DataInicio = DateTime.Now;
            promocao.DataTermino = DateTime.Now.AddMonths(3);

            promocao.IncluiProduto(p1);
            promocao.IncluiProduto(p2);
            promocao.IncluiProduto(p3);



            using (var contexto = new LojaContext())
            {
                contexto.Promocoes.Add(promocao);
                contexto.SaveChanges();

                var produto = contexto.Produtos.Where(p => p.Id == 3).SingleOrDefault();
                contexto.Produtos.Remove(produto);
                contexto.SaveChanges();

            }


        }


    }
}
