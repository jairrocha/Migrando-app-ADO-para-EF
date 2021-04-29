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
            var fulano = new Cliente();
            fulano.Nome = "Fulaninho de tal";
            fulano.EnderecoDeEntrega = new Endereco()
            {
                Numero = 12,
                Logradouro = "Rua A",
                Complemento = "Casa",
                Bairro = "Centro",
                Cidade = "A"

            };

            using (var contexto = new LojaContext())
            {
                contexto.Clientes.Add(fulano);
                contexto.SaveChanges();
            }

        }


    }
}
