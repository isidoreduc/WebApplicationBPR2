using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBPR2.Data.Entities;

namespace WebApplicationBPR2.Data.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products{ get;}
        IEnumerable<Product> ProductsOfTheWeek { get; }

        Product GetProductById(int productId);

    }
}
