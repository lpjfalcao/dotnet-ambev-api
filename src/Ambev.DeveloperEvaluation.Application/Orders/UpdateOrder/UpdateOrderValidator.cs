using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder
{
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("O Id do cliente é um campo de preenchimento obrigatório");
        }
    }
}
