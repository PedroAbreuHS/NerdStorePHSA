

using NerdStore.Core.Data;

namespace NerdStore.Catalogo.Domain
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodos();

        Task<Produto> ObterPorId(Guid id);

        Task<IEnumerable<Produto>> ObterPorCategoira(int codigo);

        Task<IEnumerable<Categoria>> ObterPorCategorias();



        void Adicionar(Produto produto);

        void Atualizar(Produto produto);



        void Adicionar(Categoria categoria);
        void Atualizar(Categoria categoria);
    }
}
