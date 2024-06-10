
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public string? Nome { get; private set; }
        public int Codigo { get; private set; }


        /*EF Relation - Lista de produtos para gerar o relacionamento*/
        public ICollection<Produto> Produtos { get; set; }

        protected Categoria() { } //Construtor aberto para facilicar o EF

        public Categoria(string? nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }


        public override string ToString()
        {
            return $" {Nome} - {Codigo} ";
        }


        public void Validar()
        {
            AssertionConcern.ValidarSeVazio(Nome, "O campo Nome da categoria não pode estar vazio.");
            AssertionConcern.ValidarSeIgual(Codigo, 0, "O campo Codigo não pode ser 0.");
        }
    }
}
