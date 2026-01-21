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

        [Theory]
        [InlineData(3, 1000, "d57fb151-b01a-44e8-bb5b-fec6225a83dc", "9a5fef4b-58c9-4885-89b8-4ff99308e577", 100)]
        [InlineData(10, 1000, "d57fb151-b01a-44e8-bb5b-fec6225a83dc", "9a5fef4b-58c9-4885-89b8-4ff99308e577", 200)]
        [InlineData(1, 1000, "d57fb151-b01a-44e8-bb5b-fec6225a83dc", "9a5fef4b-58c9-4885-89b8-4ff99308e577", 0)]
        public void ApplyDiscount_ShouldApplyDiscount_WhenCustomerBuyMoreThan4IdenticalItems(int productQuantity, int unitPrice, string productId, string customerId, decimal discount)
        {
            // Arrange
            var orderService = new OrderService();
            var customer = new Customer
            {
                Orders = new List<Order>
                {
                    new()
                    {
                        CustomerId = new Guid(customerId),
                        OrderItems = new List<OrderItem>
                        {
                            new() { ProductId = new Guid(productId), Quantity = productQuantity, UnitPrice = unitPrice }
                        }
                    }
                }
            };
            var newOrder = new Order
            {
                CustomerId = new Guid(customerId),
                OrderItems = new List<OrderItem>
                {
                    new()
                    {
                        ProductId = new Guid(productId),
                        Quantity = 1,
                        UnitPrice = 1000

                    }
                }
            };

            // Act
            orderService.ApplyDiscount(newOrder, customer);

            // Assert
            Assert.Equal(discount, newOrder.OrderItems.First().Discount);
        }
    }
}
