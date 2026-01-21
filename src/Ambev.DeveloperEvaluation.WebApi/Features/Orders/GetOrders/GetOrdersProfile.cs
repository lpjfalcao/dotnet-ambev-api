using Ambev.DeveloperEvaluation.Application.Orders.GetOrder;
using Ambev.DeveloperEvaluation.Application.Orders.GetOrders;
using Ambev.DeveloperEvaluation.WebApi.Features.Orders.GetOrder;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.GetOrders
{
    public class GetOrdersProfile : Profile
    {
        public GetOrdersProfile()
        {
            CreateMap<GetOrdersRequest, GetOrdersCommand>();
            CreateMap<GetOrderResult, GetOrderResponse>();
            CreateMap<CustomerResult, CustomerResponse>();
            CreateMap<BranchResult, BranchResponse>();
            CreateMap<GetOrderItemResult, OrderItemResponse>();
        }
    }
}
