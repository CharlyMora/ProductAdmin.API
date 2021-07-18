using ProductAdmin.API.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAdmin.API.Models
{
    
    public abstract class ProductForManipulationDto
    {

        [Required(ErrorMessage = "A name no longer than 60 characters is needed")]
        [MaxLength(60, ErrorMessage = "Name has to be maximun 60 characters")]
        public string ShortName { get; set; }

        [Required(ErrorMessage = "A description no longer than 1500 characters is needed")]
        [MaxLength(1500, ErrorMessage = "Description has to be maximun 1500 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "A product status is needed, you can use Activo or Inactivo")]
        public string ProductStatus { get; set; }

        [Required(ErrorMessage = "A value is needed")]
        public long Value { get; set; }

        [Required(ErrorMessage = "A buy date is needed")]
        public DateTime BuyDate { get; set; }
    }
}


