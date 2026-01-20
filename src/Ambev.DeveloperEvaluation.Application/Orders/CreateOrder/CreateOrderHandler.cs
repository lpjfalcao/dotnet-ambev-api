using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, CreateOrderResult>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;       

        public CreateOrderHandler(IMediator mediator, IMapper mapper, IOrderService orderService, IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _orderService = orderService;
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public async Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderValidator();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new DomainException("Ocorreu um ou mais erros durante a validação dos dados");

            Order newOrder = new();

            var customer = await _customerRepository.GetCustomerSalesInfo(request.CustomerId);

            if (customer is null)
                throw new DomainException($"O cliente de ID {request.CustomerId} não foi encontrado");

            foreach (var orderItem in request.OrderItems)
            {
                newOrder = _mapper.Map<Order>(request);

                _orderService.ApplyDiscount(newOrder, customer);
            }

            newOrder.CalculateTotalAmout();

            var newOrderCreated = await _orderRepository.Create(newOrder);

            await _mediator.Publish(new CreateOrderNotification
            {
                Id = newOrderCreated.Id,
                CustomerName = customer.Name,
                OrderDate = newOrderCreated.OrderDate,
                TotalAmount = newOrderCreated.TotalAmount,
                IsCancelled = newOrderCreated.IsCancelled
            });

            return this._mapper.Map<CreateOrderResult>(newOrderCreated);           
        }
    }
}
