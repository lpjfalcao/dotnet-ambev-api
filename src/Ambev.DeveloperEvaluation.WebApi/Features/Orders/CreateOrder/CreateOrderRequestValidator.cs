using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("O Id do cliente é um campo de preenchimento obrigatório");
            RuleFor(x => x.BranchId).NotEmpty().WithMessage("O Id da filiam é um campo de preenchimento obrigatório");
            RuleFor(x => x.OrderDate).NotEmpty().WithMessage("A Data do Pedido é um campo de preenchimento obrigatório");
        }
    }
}
