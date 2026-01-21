using Ambev.DeveloperEvaluation.Application.Orders.DeleteOrder;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.DeleteOrder
{
    public class DeleteOrderProfile : Profile
    {
        public DeleteOrderProfile()
        {
            CreateMap<Guid, Application.Orders.DeleteOrder.DeleteOrderCommand>()
                .ConstructUsing(id => new Application.Orders.DeleteOrder.DeleteOrderCommand(id));

            CreateMap<DeleteOrderRequest, DeleteOrderCommand>();
        }
    }
}
