using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Promocao
    {
        public int Id { get; set; }
        public string Descricao { get; internal set; }
        public DateTime DataInicio { get; internal set; }
        public DateTime DataTermino { get; internal set; }

        // Relacionamento N TO M (Não funciona dessa forma nessa versão (1.1.1) do EF)
        //public IList<Produto> Produtos { get; internal set; }

        //Relacionamento N TO M (Nessa versão de EF é necessário representar em uma classe (PromocaoProduto) )
        public IList<PromocaoProduto> Produtos { get; internal set; }



        public Promocao()
        {
            this.Produtos = new List<PromocaoProduto>();
        }



        public void IncluiProduto(Produto produto)
        {
            this.Produtos.Add(new PromocaoProduto() {Produto = produto });
        }
    }
}
