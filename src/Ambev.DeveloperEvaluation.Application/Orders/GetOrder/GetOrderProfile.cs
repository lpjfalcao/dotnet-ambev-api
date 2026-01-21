using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Orders.GetOrder
{
    public class GetOrderProfile : Profile
    {
        public GetOrderProfile()
        {
            CreateMap<Order, GetOrderResult>();
            CreateMap<OrderItem, GetOrderItemResult>();
            CreateMap<Customer, CustomerResult>();
            CreateMap<Branch, BranchResult>();
        }
    }
}
