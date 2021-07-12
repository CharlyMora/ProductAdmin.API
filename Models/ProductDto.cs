using ProductAdmin.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAdmin.API.Models
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public string ProductType { get; set; }

        public string ProductStatus { get; set; }
    }
}

