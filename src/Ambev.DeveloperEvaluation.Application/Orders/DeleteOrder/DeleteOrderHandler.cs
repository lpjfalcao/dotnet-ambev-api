using Ambev.DeveloperEvaluation.Application.Orders.CreateOrder;
using Ambev.DeveloperEvaluation.Application.Orders.GetOrder;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.DeleteOrder
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMediator _mediator;

        public DeleteOrderHandler(IOrderRepository orderRepository, IMediator mediator)
        {
            _orderRepository = orderRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteOrderValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var order = await _orderRepository.GetByConditionAsync(x => x.Id == request.Id);

            if (order is null)
                throw new DomainException($"O pedido de id {request.Id} não foi encontrado");

            await _orderRepository.Remove(order);

            await _mediator.Publish(new DeleteOrderNotification
            {
                Message = $"O pedido de id {request.Id} foi excluído com sucesso"
            });

            return true;
        }
    }
}
