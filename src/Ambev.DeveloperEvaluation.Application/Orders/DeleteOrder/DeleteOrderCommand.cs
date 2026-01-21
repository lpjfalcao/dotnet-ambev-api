using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteOrderCommand(Guid id)
        {
            Id = id;
        }
    }
}
