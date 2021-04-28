using System.ComponentModel.DataAnnotations;

namespace Alura.Loja.Testes.ConsoleApp
{
    /* Obs: Nessa versão (1.1.1) do EF Core qndo temos um relacionamento para N TO M
     * É nescessário representar o mesmo em uma classe (PromocaoProduto.cs). Em versões posteriores não será
     * necessário.
     * 
     */

    public class PromocaoProduto
    {

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int PromocaoId { get; set; }
        public Promocao Promocao { get; set; }
    }
}
