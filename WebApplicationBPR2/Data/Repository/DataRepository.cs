using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBPR2.Data.Entities;

namespace WebApplicationBPR2.Data.Repository
{
    public class DataRepository : IDataRepository
    {
        private readonly DataContext _dataContext;

        public DataRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _dataContext.Products.
                        OrderBy(p => p.Title).
                        ToList();
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _dataContext.Products.
                        Where(c => c.Category == category).
                        ToList();

        }
    }
}
