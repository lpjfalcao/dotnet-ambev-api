using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.GetOrder
{
    public record GetOrdersCommand : IRequest<PaginatedList<GetOrderResult>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
