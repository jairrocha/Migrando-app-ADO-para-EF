using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    interface IProdutoDAO
    {
        void Adicionar(Produto p);
        void Atualizar(Produto p);
        IList<Produto> Produtos();
        void Remover(Produto p);
    }
}