using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.GetOrder
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersCommand, PaginatedList<GetOrderResult>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<GetOrderResult>> Handle(GetOrdersCommand request, CancellationToken cancellationToken)
        {
            var orders = _orderRepository.GetAll(x => x.Customer, x => x.Branch);

            var paginatedList = await PaginatedList<Order>.CreateAsync(orders, request.PageNumber, request.PageSize);
            var results = _mapper.Map<List<GetOrderResult>>(paginatedList);

            return new PaginatedList<GetOrderResult>(
                results,
                paginatedList.Count,
                paginatedList.CurrentPage,
                paginatedList.PageSize
                );
        }
    }
}
