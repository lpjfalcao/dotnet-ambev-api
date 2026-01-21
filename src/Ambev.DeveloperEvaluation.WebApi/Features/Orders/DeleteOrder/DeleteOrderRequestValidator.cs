using Ambev.DeveloperEvaluation.WebApi.Features.Orders.GetOrder;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.DeleteOrder
{
    public class DeleteOrderRequestValidator : AbstractValidator<DeleteOrderRequest>
    {
        public DeleteOrderRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O ID é um campo de preenchimento obrigatório");
        }
    }
}
