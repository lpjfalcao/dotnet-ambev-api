using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ServicesImp;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain
{
    public class OrderServiceTests
    {
        [Fact]
        public void ApplyDiscount_ShouldThrowDomainException_WhenIdenticalItemsExceedLimit()
        {
            // Arrange
            var orderService = new OrderService();
            var newOrder = new Order
            {
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = new Guid("d57fb151-b01a-44e8-bb5b-fec6225a83dc"), Quantity = 1 }
                }
            };
            var customer = new Customer
            {
                Orders = new List<Order>
                {
                    new Order
                    {
                        OrderItems = new List<OrderItem>
                        {
                            new OrderItem { ProductId = new Guid("d57fb151-b01a-44e8-bb5b-fec6225a83dc"), Quantity = 20 },
                            new OrderItem { ProductId = new Guid("d57fb151-b01a-44e8-bb5b-fec6225a83dc"), Quantity = 1 },
                        }
                    }
                }
            };

            // Act & Assert
            Assert.Throws<DomainException>(() => orderService.ApplyDiscount(newOrder, customer));
        }

        [Fact]
        public void ApplyDiscount_ShouldApplyTenPercentDiscount_WhenCustomerBuyMoreThan4IdenticalItems()
        {
            // Arrange
            var orderService = new OrderService();
            var customer = new Customer
            {
                Orders = new List<Order>
                {
                    new()
                    {
                        CustomerId = new Guid("9a5fef4b-58c9-4885-89b8-4ff99308e577"),
                        OrderItems = new List<OrderItem>
                        {
                            new() { ProductId = new Guid("d57fb151-b01a-44e8-bb5b-fec6225a83dc"), Quantity = 3, UnitPrice = 1000 }
                        }
                    }
                }
            };
            var newOrder = new Order
            {
                CustomerId = new Guid("9a5fef4b-58c9-4885-89b8-4ff99308e577"),
                OrderItems = new List<OrderItem>
                {
                    new()
                    {
                        ProductId = new Guid("d57fb151-b01a-44e8-bb5b-fec6225a83dc"),
                        Quantity = 1,
                        UnitPrice = 1000

                    }
                }
            };

            // Act
            orderService.ApplyDiscount(newOrder, customer);

            // Assert
            Assert.Equal(100M, newOrder.OrderItems.First().Discount);
        }
    }
}
