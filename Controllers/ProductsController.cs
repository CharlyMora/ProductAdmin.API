using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAdmin.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProductAdmin.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductsAdminRepository _producsAdminRepository;

        public ProductsController(IProductsAdminRepository producsAdminRepository)
        {
            _producsAdminRepository = producsAdminRepository ??
                throw new ArgumentNullException(nameof(producsAdminRepository));
        }

        [HttpGet()]
        public IActionResult GetProducts()
        {
            var productsFromRepo = _producsAdminRepository.GetProducts();
            // siempre va a retornar json aun cuando se le pida otro tipo de archivo
            // por ende siempre va a decir 200 ok
            return new JsonResult(productsFromRepo);
        }

        [HttpGet("{productId:guid}")]
        public IActionResult GetProducts(Guid productId)
        {
            var productsFromRepo = _producsAdminRepository.GetProduct(productId);

            if (productsFromRepo == null) return NotFound();

            return Ok(productsFromRepo);
        }
    }
}
