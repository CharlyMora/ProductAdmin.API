using ProductAdmin.API.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAdmin.API.Models
{
    public class ProductForCreationDto :ProductForManipulationDto
    {

        [Required(ErrorMessage = "A product type is needed, you can use Bienes, Vehículos, Terrenos or Apartamentos")]
        public string ProductType { get; set; }

    }
}

