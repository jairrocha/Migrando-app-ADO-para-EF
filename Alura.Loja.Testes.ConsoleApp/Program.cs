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
            var paoFrances = new Produto();
            paoFrances.Nome = "Pão Francês";
            paoFrances.PrecoUnitario = 0.40;
            paoFrances.Unidade = "Unidade";
            paoFrances.Categoria = "Padaria";

            var compra = new Compra();
            compra.Quantidade = 6;
            compra.Produto = paoFrances;
            compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;

            using (var contexto = new LojaContext())
            {
                contexto.Compras.Add(compra);
                contexto.SaveChanges();
            }


        }

                
    }
}
