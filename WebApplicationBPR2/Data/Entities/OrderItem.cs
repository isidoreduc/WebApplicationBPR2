namespace DutchTreat.Data.Entities
{
  public class OrderItem
  {
    public int Id { get; set; }
    public Product Product { get; set; } // foreign key
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public Order Order { get; set; } // foreign key
  }
}