using Microsoft.EntityFrameworkCore;
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
            //AdicionaProdutosBD();
            //IncluiPromocao();
            //GeraCompra();

            //LendoEntidade_Relacionamento_N_to_M();
            //LendoEntidade_Relacionamento_1_to_1();
            LendoEntidade_Relacionamento_1_to_N();

        }

        private static void LendoEntidade_Relacionamento_1_to_N()
        {
            using (var contexto = new LojaContext())
            {

                var produto = contexto
                        .Produtos
                        .Include(p => p.Compras)
                        .Where(p => p.Id == 1004 )
                        .FirstOrDefault();

                foreach (var item in produto.Compras)
                {
                    Console.WriteLine(item.Preco);
                }

            }
        }
        private static void LendoEntidade_Relacionamento_1_to_1()
        {
            using (var contexto = new LojaContext())
            {
                var cliente = contexto.Clientes
                    .Include(e => e.EnderecoDeEntrega)
                    .FirstOrDefault();

                Console.WriteLine(cliente.EnderecoDeEntrega.Logradouro);
            }
        }
        private static void LendoEntidade_Relacionamento_N_to_M()
        {
            using (var contexto = new LojaContext())
            {
                var produtos = contexto
                    .Promocoes
                    .Include(p => p.Produtos)
                    .ThenInclude(pp => pp.Produto)
                    .FirstOrDefault();

                foreach (var item in produtos.Produtos)
                {
                    Console.WriteLine(item.Produto.Nome);
                }
            }
        }
        private static void IncluiPromocao()
        {
            using (var contexto = new LojaContext())
            {
                var promocao = new Promocao();

                promocao.Descricao = "Queima total Janeiro 2017";
                promocao.DataInicio = new DateTime(2017, 1, 1);
                promocao.DataTermino = new DateTime(2017, 1, 31);


                var produtos = contexto
                    .Produtos
                    .Where(p => p.Categoria == "Bebidas")
                    .ToList();

                foreach (var produto in produtos)
                {
                    promocao.IncluiProduto(produto);
                }

                contexto.Promocoes.Add(promocao);
                contexto.SaveChanges();
            }
        }
        private static void AdicionaProdutosBD()
        {
            var p1 = new Produto()
            {
                Categoria = "Bebidas",
                Nome = "Cerveja heineken",
                PrecoUnitario = 3.50,
                Unidade = "Unidade"

            };
            var p2 = new Produto()
            {
                Categoria = "Bebidas",
                Nome = "Café",
                PrecoUnitario = 12.15,
                Unidade = "Unidade"

            };
            var p3 = new Produto()
            {
                Categoria = "Alimentos",
                Nome = "Macarrão",
                PrecoUnitario = 3.90,
                Unidade = "Unidade"

            };


            using (var contexto = new LojaContext())
            {
                contexto.Produtos.Add(p1);
                contexto.Produtos.Add(p2);
                contexto.Produtos.Add(p3);

                contexto.SaveChanges();
            }


        }
        private static void GeraCompra()
        {
            using (var contexto = new LojaContext())
            {
                //Seleciona produto
                var produto = contexto
                    .Produtos
                    .Where(p => p.Categoria == "Alimentos")
                    .FirstOrDefault();


                var compra = new Compra();
                compra.Quantidade = 1;
                compra.Produto = produto;
                compra.Preco = (produto.PrecoUnitario * compra.Quantidade);

                contexto.Compras.Add(compra);
                contexto.SaveChanges();
            }
        }

    }




}

