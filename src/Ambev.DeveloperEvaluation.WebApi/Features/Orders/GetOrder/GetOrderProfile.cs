using Ambev.DeveloperEvaluation.Application.Orders.GetOrder;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.GetOrder
{
    public class GetOrderProfile : Profile
    {
        public GetOrderProfile()
        {
            CreateMap<Guid, Application.Orders.GetOrder.GetOrderCommand>()
                .ConstructUsing(id => new Application.Orders.GetOrder.GetOrderCommand(id));

            CreateMap<GetOrderRequest, GetOrderCommand>();
            CreateMap<GetOrderResult, GetOrderResponse>();            
        }
    }
}
