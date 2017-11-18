using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBPR2.Data.Entities;

namespace WebApplicationBPR2.Data
{
    public class ShoppingCart //in here we keep track of the OrderItems the user has selected (for that we are using the OrderItems property - a list)
    {
        private readonly DataContext _appDbContext; // needed for the connection to database
        private ShoppingCart(DataContext appDbContext) // we inject the database context to be able to interact with database
        {
            _appDbContext = appDbContext;
        }

        public string ShoppingCartId { get; set; } // the id of the shopping cart

        public List<OrderItem> OrderItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services) // using the services injection same as in Startup class to be able to use sessions
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session; // we establish a session 

            var context = services.GetService<DataContext>(); // getting access to our database context
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString(); // check if we have already a CartId in our session, normally not, 

            session.SetString("CartId", cartId); // so we create a new one; this will link the OrderItems with the shopping cart id

            return new ShoppingCart(context) { ShoppingCartId = cartId }; // return a new ShoppingCart with has injected our database context and our newly created shopping cart id
        }

        public void AddToCart(Product product, int quantity)
        {
            var orderItem =
                    _appDbContext.OrderItems.SingleOrDefault(
                        s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId); // searches in the database if we have the product and if we are in the correct shopping cart

            if (orderItem == null) // if there is no order item, creates a new one
            {
                orderItem = new OrderItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Quantity = 1
                };

                _appDbContext.OrderItems.Add(orderItem); // and adds it to database in the OrderItems list
            }
            else
            {
                orderItem.Quantity++;
            }
            _appDbContext.SaveChanges(); // then we save changes to database
        }

        public int RemoveFromCart(Product product)
        {
            var orderItem =
                    _appDbContext.OrderItems.SingleOrDefault(
                        s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (orderItem != null)
            {
                if (orderItem.Quantity > 1)
                {
                    orderItem.Quantity--;
                    localAmount = orderItem.Quantity;
                }
                else
                {
                    _appDbContext.OrderItems.Remove(orderItem);
                }
            }

            _appDbContext.SaveChanges();

            return localAmount;
        }

        public List<OrderItem> GetOrderItems()
        {
            return OrderItems ??
                   (OrderItems =
                       _appDbContext.OrderItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Product)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext
                .OrderItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _appDbContext.OrderItems.RemoveRange(cartItems);

            _appDbContext.SaveChanges();
        }



        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.OrderItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Product.Price * c.Quantity).Sum();
            return total;
        }
    }
}
