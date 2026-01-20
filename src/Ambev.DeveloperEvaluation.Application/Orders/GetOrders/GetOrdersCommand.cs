using Ambev.DeveloperEvaluation.Application.Orders.GetOrder;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.GetOrders
{
    public record GetOrdersCommand : IRequest<PaginatedList<GetOrderResult>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
