using BLL.IService;
using DTO.DTO;
using Entity.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            try
            {
                var AllProduct = _productService.GetAllProducts();
                if (AllProduct == null)
                {
                    return NotFound();
                }
                List<ProductDto> products = new List<ProductDto>(); 
                foreach (var product in AllProduct)
                {
                    ProductDto productDto = new ProductDto();
                    productDto.ProductName = product.ProductName;
                    productDto.Id = product.Id;
                    productDto.UnitPrice = product.UnitPrice;
                    productDto.UnitInStock = product.UnitInStock;
                    productDto.Unit = (int)product.Unit;
                    productDto.CategoryNameId = product.CategoryNameId;
                    productDto.ExpirationDate = product.ExpirationDate;
                    products.Add(productDto);

                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
            
        }

        [HttpPost]
        public IActionResult AddProduct(ProductDto productDto)
        {
            try
            {
                Product product = new Product()
                { Id = 0,
                ProductName = productDto.ProductName,
                UnitPrice = productDto.UnitPrice,
                UnitInStock = productDto.UnitInStock,
                Unit = (Entity.Enum.Unit)productDto.Unit,
                CategoryNameId = productDto.CategoryNameId,
                ExpirationDate = productDto.ExpirationDate,
                };
                if (product.Id == null)
                    return BadRequest();
                _productService.AddProducts(product);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (id == null)
                    return NotFound();
                var product = _productService.GetProductById(id);
                ProductDto productDto = new ProductDto();
                productDto.ProductName = product.ProductName;
                productDto.Id = product.Id;
                productDto.UnitPrice = product.UnitPrice;
                productDto.UnitInStock = product.UnitInStock;
                productDto.Unit = (int)product.Unit;
                productDto.CategoryNameId = product.CategoryNameId;
                productDto.ExpirationDate = product.ExpirationDate;
                return Ok(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut]
        public IActionResult UpdateProduct(ProductDto productDto)
        {
            try
            {
                var savedproduct = GetById(productDto.Id);
                if (savedproduct == NotFound())
                    return NotFound("Aradığınız değere ait kayıt bulunamadı!");
                Product product = new Product()
                {
                    Id = productDto.Id,
                    ProductName = productDto.ProductName,
                    UnitPrice = productDto.UnitPrice,
                    UnitInStock = productDto.UnitInStock,
                    CategoryNameId = productDto.CategoryNameId,
                    ExpirationDate = productDto.ExpirationDate,
                };
                _productService.UpdateProducts(product);
                return Ok("Kayıt başarılı!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public IActionResult DeleteProduct(ProductDto productDto)
        {
            try
            {
                var savedproduct = GetById(productDto.Id);
                if (savedproduct == NotFound())
                    return NotFound("Aradığınız değere ait kayıt bulunamadı!");
                Product product = new Product()
                {
                    Id = productDto.Id,
                    ProductName = productDto.ProductName,
                    UnitPrice = productDto.UnitPrice,
                    UnitInStock = productDto.UnitInStock,
                    CategoryNameId = productDto.CategoryNameId,
                    ExpirationDate = productDto.ExpirationDate,
                };
                _productService.DeleteProducts(product);
                return Ok("Silme başarılı!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
