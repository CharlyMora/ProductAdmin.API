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

namespace ProductAdmin.API.Controllers
{
    [Route("api/productsCollection")]
    [ApiController]
    public class ProductsCollectionController : ControllerBase
    {
        private readonly IProductsAdminRepository _producsAdminRepository;
        private readonly IMapper _mapper;

        public ProductsCollectionController(IProductsAdminRepository producsAdminRepository,
                                  IMapper mapper)
        {
            _producsAdminRepository = producsAdminRepository ??
                throw new ArgumentNullException(nameof(producsAdminRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        //[HttpGet()]
        //[HttpHead]
        ////public ActionResult<IEnumerable<Product>> GetProducts([FromQuery(Name ="in case of variable name != from key in query string this is from query to key ")] ProductsResourceParameters productsResourceParameters)
        //public ActionResult<IEnumerable<ProductDto>> GetProducts(string search)
        //{
        //    var productsFromRepo = _producsAdminRepository.GetProducts(search);

        //    return Ok(_mapper.Map<IEnumerable<ProductDto>>(productsFromRepo));
        //}

        //[HttpGet("{productId:guid}", Name = "GetProduct")]
        //public ActionResult<ProductDto> GetProduct(Guid productId)
        //{
        //    var productsFromRepo = _producsAdminRepository.GetProduct(productId);

        //    if (productsFromRepo == null) return NotFound();

        //    return Ok(_mapper.Map<ProductDto>(productsFromRepo));
        //}

        [HttpPost]
        public ActionResult<IEnumerable<ProductDto>> CreateProductCollection(IEnumerable<ProductForCreationDto> productsCollection)
        {
            try
            {
                var productsEntities = _mapper.Map<IEnumerable<Entities.Product>>(productsCollection);
                foreach (var product in productsEntities)
                {
                    _producsAdminRepository.AddProduct(product);
                }

                //foreach (var product in productsCollection)
                //{
                //    var productEntity = _mapper.Map<Entities.Product>(product);
                //    _producsAdminRepository.AddProduct(productEntity);
                //}

                _producsAdminRepository.Save();

                return Ok("creaste LA de productos");
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

    }
}
