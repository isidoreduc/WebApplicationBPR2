using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBPR2.Data.Entities;
using WebApplicationBPR2.Data.Repository;
using WebApplicationBPR2.ViewModels;

namespace WebApplicationBPR2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        
        public ViewResult List(string categoryName)
        {
            IEnumerable<Product> products;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(categoryName))
            {
                products = _productRepository.Products.OrderBy(p => p.Id);
                currentCategory = "All products";
            }
            else
            {
                products = _productRepository.Products.Where(p => p.Category.CategoryName == categoryName)
                   .OrderBy(p => p.Id);
                currentCategory = _productRepository.Products.FirstOrDefault(c => c.Category.CategoryName == categoryName).Category.CategoryName;
            }

            return View(new ProductListViewModel
            {
                Products = products,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

    }
}

