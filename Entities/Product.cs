using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAdmin.API.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1500)]
        public string Description { get; set; }

        [Required]
        public ProductType ProductType { get; set; }

        [Required]
        public long Value { get; set; }

        public DateTime BuyDate { get; set; }

        [Required]
        public ProductStatus ProductStatus { get; set; }
    }
}
