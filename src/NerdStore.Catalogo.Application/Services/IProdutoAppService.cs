﻿
using NerdStore.Catalogo.Application.ViewModelsOrDTOs;

namespace NerdStore.Catalogo.Application.Services
{
    public interface IProdutoAppService : IDisposable
    {
        Task<IEnumerable<ProdutoDTO>> ObterPorCategoria(int codigo);
        Task<ProdutoDTO> ObterPorId(Guid id);
        Task<IEnumerable<ProdutoDTO>> ObterTodos();
        Task<IEnumerable<CategoriaDTO>> ObterCategorias();


        Task AdicionarProduto(ProdutoDTO produtoDTO);
        Task AtualizarProduto(ProdutoDTO produtoDTO);


        Task<ProdutoDTO> DebitarEstoque(Guid id, int quantidade);
        Task<ProdutoDTO> ReporEstoque(Guid id, int quantidade);
    }
}
