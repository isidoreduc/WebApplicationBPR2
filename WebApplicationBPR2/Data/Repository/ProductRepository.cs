using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBPR2.Data.Entities;

namespace WebApplicationBPR2.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Product> Products
        {
            get
            {
                return _dataContext.Products.Include(c => c.Category);
            }
        }

        public IEnumerable<Product> ProductsOfTheWeek
        {
            get
            {
                return _dataContext.Products.Include(c => c.Category).Where(p => p.IsProductOfTheWeek);
            }
        }

        

        public Product GetProductById(int productId)
        {
            return _dataContext.Products.FirstOrDefault(p => p.Id == productId);
        }
    }
}
