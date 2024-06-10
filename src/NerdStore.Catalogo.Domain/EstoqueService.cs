

using NerdStore.Catalogo.Domain.Events;
using NerdStore.Core.BusInMemory;

namespace NerdStore.Catalogo.Domain
{
    public class EstoqueService : IEstoqueService
    {

        private readonly IProdutoRepository _produtoRepository;

        private readonly IMediatrHandler _bus;

        public EstoqueService(IProdutoRepository repository, 
                              IMediatrHandler bus)
        {
            _produtoRepository = repository;
            _bus = bus;
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;

            if (!produto.PossuiEstoque(quantidade)) return false;

            produto.DebitarEstoque(quantidade);

            if (produto.QuantidadeEstoque < 10)
            {
               await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QuantidadeEstoque));
            }

            _produtoRepository.Atualizar(produto);

            return await _produtoRepository.UniteOfWork.Commit();
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;
            produto.ReporEstoque(quantidade);

            _produtoRepository.Atualizar(produto);

            return await _produtoRepository.UniteOfWork.Commit();
        }
        public void Dispose()
        {
            _produtoRepository.Dispose();
        }

        
    }
}
