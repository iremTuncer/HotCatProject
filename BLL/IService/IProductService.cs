using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();

        void AddProducts(Product product);

        void UpdateProducts(Product products);

        void DeleteProducts(Product products);

        Product GetProductById(int id);
    }
}
