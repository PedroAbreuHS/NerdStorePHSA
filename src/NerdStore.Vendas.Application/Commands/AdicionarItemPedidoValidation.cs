

using FluentValidation;

namespace NerdStore.Vendas.Application.Commands
{
    public class AdicionarItemPedidoValidation : AbstractValidator<AdicionarItemPedidoCommand>
    {
        public AdicionarItemPedidoValidation()
        {
            RuleFor(C => C.ClienteId)
                .NotEqual(Guid.Empty).WithMessage("Id do cliente está inválido!");

            RuleFor(c => c.ProdutoId)
                .NotEqual(Guid.Empty).WithMessage("Id do produto está inválido!");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do produto não foi informado!");

            RuleFor(c => c.Quantidade)
                .GreaterThan(0).WithMessage("A quantidade mínima de um item é 1!");

            RuleFor(c => c.Quantidade)
                .LessThan(15).WithMessage("A quantidade máxima de um item são 15!");

            RuleFor(c => c.ValorUnitario)
                .GreaterThan(0).WithMessage("O valor do item precisa ser maior que 0!");
        }
    }
}
