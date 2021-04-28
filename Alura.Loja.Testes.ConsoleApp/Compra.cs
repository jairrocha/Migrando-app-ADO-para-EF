using System.ComponentModel.DataAnnotations;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Compra
    {

        public int Id { get; set; }
        public int Quantidade { get; internal set; }
        [Required]
        public Produto Produto { get; internal set; }
        public double Preco { get; internal set; }
    }
}