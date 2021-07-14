using AutoMapper;
using ProductAdmin.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAdmin.API.Profiles
{
    public class ProductsProfile: Profile
    {
        public ProductsProfile()
        {
            CreateMap<Entities.Product, Models.ProductDto>()
                .ForMember(
                    dest => dest.ProductStatus,
                    opt => opt.MapFrom(src => Enum.GetName(typeof(ProductStatus),src.ProductStatus))
                    )
                .ForMember(
                    dest => dest.ProductType,
                    opt => opt.MapFrom(src => Enum.GetName(typeof(ProductType), src.ProductType))
                    );

            CreateMap<Entities.Product, Models.ProductFullDto>()
                .ForMember(
                    dest => dest.ProductStatus,
                    opt => opt.MapFrom(src => Enum.GetName(typeof(ProductStatus), src.ProductStatus))
                    )
                .ForMember(
                    dest => dest.ProductType,
                    opt => opt.MapFrom(src => Enum.GetName(typeof(ProductType), src.ProductType))
                    );

            CreateMap<Models.ProductForCreation, Entities.Product>()
                .ForMember(
                    dest => dest.ProductStatus,
                    opt => opt.MapFrom(src=> Enum.Parse(typeof(ProductStatus), src.ProductStatus)))
                .ForMember(
                    dest => dest.ProductType,
                    opt => opt.MapFrom(src => Enum.Parse(typeof(ProductType), src.ProductType))
                    );
        }
    }
}
