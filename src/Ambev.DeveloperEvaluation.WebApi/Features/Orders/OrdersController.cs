using Ambev.DeveloperEvaluation.Application.Orders.CreateOrder;
using Ambev.DeveloperEvaluation.Application.Orders.GetOrder;
using Ambev.DeveloperEvaluation.Application.Orders.GetOrders;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.CreateOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.GetOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.GetOrders;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrdersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetOrderResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrder([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new GetOrderRequest { Id = id };
            var validator = new GetOrderRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetOrderCommand>(request.Id);
            var response = await _mediator.Send(command, cancellationToken);

            return StatusCode((int)HttpStatusCode.OK, new ApiResponseWithData<GetOrderResponse>
            {
                Success = true,
                Data = _mapper.Map<GetOrderResponse>(response)
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResponse<GetOrderResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrders([FromQuery] GetOrdersRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<GetOrdersCommand>(request);

            var response = await _mediator.Send(command, cancellationToken);

            return StatusCode((int)HttpStatusCode.OK, new PaginatedResponse<GetOrderResponse>
            {
                Success = true,
                Data = _mapper.Map<List<GetOrderResponse>>(response),
                CurrentPage = response.CurrentPage,
                TotalCount = response.TotalCount,
                TotalPages = response.TotalPages
            });
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateOrderResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateOrderCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return StatusCode((int)HttpStatusCode.OK, new ApiResponseWithData<CreateOrderResponse>
            {
                Success = true,
                Message = "Seu pedido foi realizado com sucesso!",
                Data = _mapper.Map<CreateOrderResponse>(response)
            });
        }
    }
}
