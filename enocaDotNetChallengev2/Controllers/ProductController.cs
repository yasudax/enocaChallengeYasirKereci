using BusinessLayer.Managers;
using BusinessLayer.Managers.Interfaces;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace enocaDotNetChallengev2.Controllers
{
    [ApiController]
    [Route("api/product")]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpPost]
        [Route("add-product")]
        [SwaggerOperation(Summary = "Ürün Ekleme", Description = "Tabloya tüm bilgiler eklenebilmelidir.")]
        public IActionResult AddProduct(Product request)
        {
            var result = _productManager.AddProduct(request);
            return Ok(result);
        }

        [HttpGet("list-products")]
        [SwaggerOperation(Summary = "Ürün Listeleme", Description = "Tüm ürünler listelenecektir.")]
        public IActionResult GetAllProduct()
        {
            var products = _productManager.GetAllProduct();
            return Ok(products);
        }
    }
}
