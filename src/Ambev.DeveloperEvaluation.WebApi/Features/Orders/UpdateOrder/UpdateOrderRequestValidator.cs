using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.UpdateOrder
{
    public class UpdateOrderRequestValidator : AbstractValidator<UpdateOrderRequest>
    {
        public UpdateOrderRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O ID do pedido é um campo de preenchimento obrigatório");
        }
    }
}
