using Microsoft.EntityFrameworkCore;
using ProductAdmin.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAdmin.API.DbContexts
{
    public class ProductsAdminContext: DbContext
    {
        public ProductsAdminContext(DbContextOptions<ProductsAdminContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { 
                    Id= Guid.NewGuid(),
                    ShortName = "apartamento en barrio alqueria",
                    Description = "apartamento con gran amplitud apesar de dimensiones teccnicas, paredes blancas y vista a las montañas",
                    ProductType = ProductType.Apartamentos,
                    Value = 111000000,
                    BuyDate = new DateTime(2011,1,11),
                    ProductStatus = ProductStatus.Activo
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    ShortName = "Casa en alqueria la fragua",
                    Description = "Gran lote con casa casi lista para ser demolida y reconstruida",
                    ProductType = ProductType.Terrenos,
                    Value = 222000000,
                    BuyDate = new DateTime(2012, 2, 12),
                    ProductStatus = ProductStatus.Activo
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    ShortName = "Muebles para casa",
                    Description = "Muebles de casa recien demolida listos para encontrar un nuevo hogar",
                    ProductType = ProductType.Bienes,
                    Value = 33000000,
                    BuyDate = new DateTime(2013, 3, 30),
                    ProductStatus = ProductStatus.Inactivo
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    ShortName = "Renault 6 clasico",
                    Description = "Primer renault 6 de colombia con placas clasicas, naturalemnte en perfecto estado",
                    ProductType = ProductType.Vehículos,
                    Value = 44000000,
                    BuyDate = new DateTime(2014, 4, 24),
                    ProductStatus = ProductStatus.Activo
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    ShortName = "Apartamento calle 13 con boyaca",
                    Description = "Linto apartamento solo habitado por una pareja de hermanos, grande y queda cerca a dos centros comerciales, el eden y multiplaza",
                    ProductType = ProductType.Apartamentos,
                    Value = 555000000,
                    BuyDate = new DateTime(2015, 5, 15),
                    ProductStatus = ProductStatus.Inactivo
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    ShortName = "Finca lechera",
                    Description = "Fina a las afuera de bogota por el norte, solia estar dedicada a la industria lechera, gangazo",
                    ProductType = ProductType.Terrenos,
                    Value = 660000000,
                    BuyDate = new DateTime(2016, 6,26),
                    ProductStatus = ProductStatus.Activo
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    ShortName = "Camioneta gran vitara",
                    Description = "Hermosa camioneta gran vitara modelo 20 color rojo, la vendemos por que nos vamos del pais, oferta imperdible",
                    ProductType = ProductType.Vehículos,
                    Value = 7000000,
                    BuyDate = new DateTime(2021, 7, 7),
                    ProductStatus = ProductStatus.Activo
                }
                );
        }

    }
}
