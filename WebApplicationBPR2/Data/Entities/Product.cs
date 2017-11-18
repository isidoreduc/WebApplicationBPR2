using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationBPR2.Data.Entities
{
    // list of properties about a product we store in our database
    public class Product
    {
        // id = primary key for our entity, it is going to be autoincremented with each product added
        public int Id { get; set; }
        
        public int Size { get; set; } //in grams
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoId { get; set; }
        public bool InStock { get; set; }
        public bool IsProductOfTheWeek { get; set; }
        public virtual Category Category { get; set; }

    }
}

