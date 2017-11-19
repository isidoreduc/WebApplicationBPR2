using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBPR2.Data.Entities;

namespace WebApplicationBPR2.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(DataContext dataContext, ShoppingCart shoppingCart)
        {
            _dataContext = dataContext;
            _shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderDate = DateTime.Now;

            _dataContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.OrderItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderItem = new OrderItem()
                {
                    Quantity = shoppingCartItem.Quantity,
                    OrderItemId = shoppingCartItem.Product.Id,
                    UnitPrice = shoppingCartItem.Product.Price
                };

                _dataContext.OrderItems.Add(orderItem);
            }

            _dataContext.SaveChanges();
        }
    }
}
