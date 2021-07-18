using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAdmin.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductAdmin.API.Entities;
using ProductAdmin.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace ProductAdmin.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsAdminRepository _producsAdminRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductsAdminRepository producsAdminRepository,
                                  IMapper mapper)
        {
            _producsAdminRepository = producsAdminRepository ??
                throw new ArgumentNullException(nameof(producsAdminRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        //[HttpGet()]
        //public IActionResult GetProducts()
        //{
        //    var productsFromRepo = _producsAdminRepository.GetProducts();
        //    // siempre va a retornar json aun cuando se le pida otro tipo de archivo
        //    // por ende siempre va a decir 200 ok
        //    return new JsonResult(productsFromRepo);
        //}

        [HttpGet()]
        [HttpHead]
        //public ActionResult<IEnumerable<Product>> GetProducts([FromQuery(Name ="in case of variable name != from key in query string this is from query to key ")] ProductsResourceParameters productsResourceParameters)
        public ActionResult<IEnumerable<ProductDto>> GetProducts(string search)
        {
            var productsFromRepo = _producsAdminRepository.GetProducts(search);

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(productsFromRepo));
        }

        [HttpGet("{productId:guid}", Name = "GetProduct")]
        public ActionResult<ProductDto> GetProduct(Guid productId)
        {
            var productsFromRepo = _producsAdminRepository.GetProduct(productId);

            if (productsFromRepo == null) return NotFound();

            return Ok(_mapper.Map<ProductDto>(productsFromRepo));
        }
        [HttpPost]
        public ActionResult<ProductDto> CreateProduct(ProductForCreationDto product)
        {

            if (product.BuyDate.Ticks == 0)
            {
                return BadRequest("Buydate is needed");
            }

            if (product.Value == 0)
            {
                return BadRequest("Value is needed");
            }

            try
            {

                    var productEntity = _mapper.Map<Entities.Product>(product);
                    _producsAdminRepository.AddProduct(productEntity);
                    _producsAdminRepository.Save();
                    var productToReturn = _mapper.Map<ProductDto>(productEntity);

                    return CreatedAtRoute("GetProduct", new { productId = productToReturn.Id }, productToReturn);
          
            }
            catch (AutoMapperConfigurationException ex)
            {

                Console.WriteLine(ex.InnerException?.Message);
                Console.WriteLine(ex.GetType());

                return BadRequest(ex.InnerException?.Message);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.InnerException?.Message);
                Console.WriteLine(ex.GetType());

                return BadRequest(ex.InnerException?.Message);
            }
            
            
        }

        //to be removed, needs to be improved
        [HttpGet("full")]
        public ActionResult<IEnumerable<ProductFullDto>> GetFullProducts(string search)
        {
            var productsFromRepo = _producsAdminRepository.GetProducts(search);

            return Ok(_mapper.Map<IEnumerable<ProductFullDto>>(productsFromRepo));
        }

        //to be removed, needs to be improved
        [HttpGet("full/{productId:guid}")]
        public ActionResult<ProductFullDto> GetFullProduct(Guid productId)
        {
            var productsFromRepo = _producsAdminRepository.GetProduct(productId);

            if (productsFromRepo == null) return NotFound();

            return Ok(_mapper.Map<ProductFullDto>(productsFromRepo));
        }

        [HttpPut("{productId:guid}")]
        public ActionResult UpdateProduct(Guid productId, ProductForUpdateDto product) {

            if(product.BuyDate.Ticks == 0)
            {
                return BadRequest("Buydate is needed");
            }

            if (product.Value == 0)
            {
                return BadRequest("Value is needed");
            }

            //implement in other gets?
            if (!_producsAdminRepository.ProductExists(productId))
            {
                return NotFound();
            }

            var productFormRepo = _producsAdminRepository.GetProduct(productId);

            if (productFormRepo == null) return NotFound();

            // map the entity to a ProductForUpdateDto
            // apply the updated field values to that dto
            // map the ProductForUpdateDto back to an entity

            _mapper.Map(product, productFormRepo);

            _producsAdminRepository.UpdateProduct(productFormRepo);
            _producsAdminRepository.Save();

            return Ok("Updated product with id: "+productId);
        }

        //[HttpPatch("{productId:guid}")]
        //public ActionResult PartialUpdateProduct(Guid productId, JsonPatchDocument<ProductForUpdateDto> patchDocument)
        //{

        //    if (!_producsAdminRepository.ProductExists(productId))
        //    {
        //        return NotFound();
        //    }

        //    var productFormRepo = _producsAdminRepository.GetProduct(productId);

        //    if (productFormRepo == null) return NotFound();

        //    var productToPatch = _mapper.Map<ProductForUpdateDto>(productFormRepo);

        //    try
        //    {
        //        patchDocument.ApplyTo(productToPatch);
        //    }
        //    catch (Exception)
        //    {

        //        return BadRequest("something went wrong with the information provided to patch");
        //    }

            

        //    _mapper.Map(productToPatch, productFormRepo);

        //    _producsAdminRepository.UpdateProduct(productFormRepo);
        //    _producsAdminRepository.Save();

        //    //return Ok("Updated product with id: " + productId);

        //    return NoContent();
        //}
    }
}
