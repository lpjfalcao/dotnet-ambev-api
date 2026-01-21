using Ambev.DeveloperEvaluation.Application.Orders.CreateOrder;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderResult>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderHandler(IMediator mediator, IMapper mapper, IOrderRepository orderRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<UpdateOrderResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOrderValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new DomainException("Ocorreu um ou mais erros durante a validaão dos dados");

            var order = await _orderRepository.GetByConditionAsync(x => x.Id == request.Id, x => x.Branch, x => x.Customer) ??
                  throw new DomainException($"O pedido de id {request.Id} não foi encontrado"); ;

            var orderUpdated = await _orderRepository.Update(_mapper.Map(request, order));

            await _mediator.Publish(new CreateOrderNotification
            {
                Id = orderUpdated.Id,
                OrderDate = orderUpdated.OrderDate,
                TotalAmount = orderUpdated.TotalAmount,
                IsCancelled = orderUpdated.IsCancelled
            });

            return this._mapper.Map<UpdateOrderResult>(orderUpdated);
        }
    }
}
