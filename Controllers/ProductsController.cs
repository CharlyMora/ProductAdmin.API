﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAdmin.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProductAdmin.API.Entities;
using ProductAdmin.API.Models;
using AutoMapper;

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
        //public ActionResult<IEnumerable<Product>> GetProducts([FromQuery(Name ="in case of variable name != from key in query string this is from query to key ")] ProductsResourceParameters productsResourceParameters)
        public ActionResult<IEnumerable<ProductDto>> GetProducts(string search)
        {
            var productsFromRepo = _producsAdminRepository.GetProducts(search);

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(productsFromRepo));
        }


        [HttpGet("{productId:guid}")]
        public ActionResult<ProductDto> GetProduct(Guid productId)
        {
            var productsFromRepo = _producsAdminRepository.GetProduct(productId);

            if (productsFromRepo == null) return NotFound();

            return Ok(_mapper.Map<ProductDto>(productsFromRepo));
        }
    }
}
