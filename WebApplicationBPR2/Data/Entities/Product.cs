using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Data.Entities
{
    // list of properties about a product we store in our database
  public class Product
  {
        // id = primary key for our entity, it is going to be autoincremented with each product added
    public int Id { get; set; }
    public string Category { get; set; }
    public int Size { get; set; } //in grams
    public decimal Price { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
      //------------------------------------------------ to remove -----------------------------------------------  
        //public string ArtDating { get; set; }
    //public string ArtId { get; set; }
    //public string Artist { get; set; }
    //public DateTime ArtistBirthDate { get; set; }
    //public DateTime ArtistDeathDate { get; set; }
    //public string ArtistNationality { get; set; }
  }
}
