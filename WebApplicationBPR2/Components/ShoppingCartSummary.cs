using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBPR2.Data;
using WebApplicationBPR2.Data.Entities;
using WebApplicationBPR2.ViewModels;

namespace WebApplicationBPR2.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke() // the same as the Index method of the ShoppingCartController
        {
            var items = _shoppingCart.GetOrderItems(); // requesting for all order items from database
            //var items = new List<OrderItem> { new OrderItem(), new OrderItem() }; // just a mock data for testing of the front page glyph thet should show 2 items in my basket
            _shoppingCart.OrderItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel // creating a new viewmodel which contains
            {
                ShoppingCart = _shoppingCart, // the shopping cart
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal() // and total
            };

            return View(shoppingCartViewModel); // and passing this viewmodel to the view
        }
    }
}
