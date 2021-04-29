using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Produto
    {
        public int Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Categoria { get; internal set; }
        public double PrecoUnitario { get; internal set; }
        public string Unidade { get; set; }
        
        // Relacionamento N TO M (Não funciona dessa forma nessa versão (1.1.1) do EF)
        //public IList<Promocao> Promocoes { get; set; }

        //Relacionamento N TO M (Nessa versão de EF é necessário representar em uma classe (PromocaoProduto) )
        public IList<PromocaoProduto> Promocoes { get; set; }
        public IList<Compra> Compras  { get; set; }

    }
}