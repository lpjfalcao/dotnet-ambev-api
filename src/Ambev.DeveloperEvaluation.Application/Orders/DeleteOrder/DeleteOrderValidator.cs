using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Orders.DeleteOrder
{
    public class DeleteOrderValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O id do pedido é um campo de preenchimento obrigatório");
        }
    }
}
