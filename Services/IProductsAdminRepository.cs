using ProductAdmin.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ProductAdmin.API.Services
{
    public interface IProductsAdminRepository
    {
        IEnumerable<Product> GetProducts([Optional] ProductType productType, [Optional] ProductStatus productStatus);
        Product GetProduct(Guid productId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        bool ProductExists(Guid productId);
        IEnumerable<Product> GetProducts(string searchParameters);
        bool Save();
    }
}
