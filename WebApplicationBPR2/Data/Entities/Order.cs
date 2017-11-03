using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Data.Entities
{
  public class Order
  {
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderNumber { get; set; }
        // this is how we mark a parent-child relationship in our model (one to many in this case)
    public ICollection<OrderItem> Items { get; set; }
  }
}
