namespace WebApplicationBPR2.Data.Entities
{
    public class OrderItem // for each product added to cart we will create an instance of the OrderItem
    {
        public int OrderItemId { get; set; }
        public Product Product { get; set; } // foreign key
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Order Order { get; set; } // foreign key
        
        public string ShoppingCartId { get; set; } // used to link the item with the personal shopping cart id of the user
    }
}
