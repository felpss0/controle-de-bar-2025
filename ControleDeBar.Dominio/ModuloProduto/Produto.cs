using ControleDeBar.Dominio.Compartilhado;

namespace ControleDeBar.Dominio.ModuloProduto
{
    public class Produto : EntidadeBase<Produto>
    {
        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public Produto(){}

        public Produto(string nome, decimal preco) : this()
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Preco = preco;

        }

        public override void AtualizarRegistro(Produto registroEditado)
        {
            Nome = registroEditado.Nome;
            Preco = registroEditado.Preco;
        }
    }
}
