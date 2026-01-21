using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.GetOrder
{
    public class GetOrderHandler : IRequestHandler<GetOrderCommand, GetOrderResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<GetOrderResult> Handle(GetOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetOrderValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var order = await _orderRepository.GetByConditionAsync(x => x.Id == request.Id, x => x.Branch, x => x.Customer, x => x.OrderItems);

            if (order == null)
                throw new KeyNotFoundException($"O pedido de id: {request.Id} não foi encontrado");

            return _mapper.Map<GetOrderResult>(order);
        }
    }
}
