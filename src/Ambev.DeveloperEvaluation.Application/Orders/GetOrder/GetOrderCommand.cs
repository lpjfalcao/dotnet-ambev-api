using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.GetOrder
{
    public record GetOrderCommand : IRequest<GetOrderResult>
    {
        public Guid Id { get; set; }

        public GetOrderCommand(Guid id)
        {
            Id = id;
        }
    }
}
