using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Orders.GetOrder
{
    public class GetOrderValidator : AbstractValidator<GetOrderCommand>
    {
        public GetOrderValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O ID do pedido é um campo obrigatório");
        }
    }
}
