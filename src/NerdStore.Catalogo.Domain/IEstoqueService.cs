
namespace NerdStore.Catalogo.Domain
{
    public interface IEstoqueService : IDisposable
    {
        public Task<bool> DebitarEstoque(Guid produtoId, int quantidade);

        public Task<bool> ReporEstoque(Guid produtoId, int quantidade);
    }
}
