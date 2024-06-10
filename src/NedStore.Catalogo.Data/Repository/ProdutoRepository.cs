
using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.Data;

namespace NedStore.Catalogo.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoDBContext _dbContext;

        public ProdutoRepository(CatalogoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUniteOfWork UniteOfWork => _dbContext;

        public void Adicionar(Produto produto)
        {
            _dbContext.Produtos.Add(produto);
        }

        public void Adicionar(Categoria categoria)
        {
            _dbContext.Categorias.Add(categoria);
        }

        public void Atualizar(Produto produto)
        {
            _dbContext.Produtos.Update(produto);
        }

        public void Atualizar(Categoria categoria)
        {
            _dbContext.Categorias.Update(categoria);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public async Task<IEnumerable<Produto>> ObterPorCategoira(int codigo)
        {
            return await _dbContext.Produtos.AsNoTracking()
                .Include(p => p.Categoria).Where(c => c.Categoria.Codigo == codigo).ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> ObterPorCategorias()
        {
            return await _dbContext.Categorias.AsNoTracking().ToListAsync();
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await _dbContext.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _dbContext.Produtos.AsNoTracking().ToListAsync();
        }
    }
}
