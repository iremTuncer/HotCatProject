using BLL.IService;
using BLL.Repository;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productService;
        public ProductService(IRepository<Product> productService)
        {
            _productService = productService;
        }
        public void AddProducts(Product product)
        {
            _productService.Insert(product);
        }

        public void DeleteProducts(Product product)
        {
            _productService.Delete(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
           return _productService.GetAll().ToList();
        }

        public Product GetProductById(int id)
        {
            return _productService.Get(id);
        }

        public void UpdateProducts(Product product)
        {
            _productService.Update(product);
        }
    }
}
