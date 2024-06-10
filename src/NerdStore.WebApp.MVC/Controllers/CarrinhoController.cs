using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.Services;

namespace NerdStore.WebApp.MVC.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;

        public CarrinhoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("meu-carrinho")]
        public async Task<IActionResult> AdicionarItem(Guid id, int quantidade)
        {
            var produto = await _produtoAppService.ObterPorId(id);
            if (produto == null) return BadRequest();

            if (produto.QuantidadeEstoque < quantidade)
            {
                TempData["Error"] = "Produto com estoque insuficiente.";
                return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
            }

            
        }
    }
}
