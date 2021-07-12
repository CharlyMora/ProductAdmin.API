using ProductAdmin.API.DbContexts;
using ProductAdmin.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ProductAdmin.API.Services
{
    public class ProductsAdminRepository : IProductsAdminRepository, IDisposable
    {
        private readonly ProductsAdminContext _context;

        public ProductsAdminRepository(ProductsAdminContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddProduct(Product product){
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.Products.Add(product);
        }

        public void DeleteProduct(Product product) {
            _context.Products.Remove(product);
        }

        public Product GetProduct(Guid productId) {
            if (productId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(productId));
            }

            return _context.Products.Where(p => p.Id == productId)
                .FirstOrDefault();

        }

        public IEnumerable<Product> GetProducts([Optional] ProductType productType, [Optional] ProductStatus productStatus) {
            if (String.IsNullOrWhiteSpace(productType.ToString()) &&
                String.IsNullOrWhiteSpace(productStatus.ToString()))
            {
                return _context.Products.Where(p =>
                    p.ProductType == productType &&
                    p.ProductStatus == productStatus
                ).ToList();
            }
            else if (String.IsNullOrWhiteSpace(productStatus.ToString()))
            {
                return _context.Products.Where(p =>
                    p.ProductStatus == productStatus
                ).ToList();
            }
            else if (String.IsNullOrWhiteSpace(productType.ToString()))
            {
                return _context.Products.Where(p =>
                    p.ProductType == productType
                ).ToList();
            }
            else {
                return _context.Products.ToList();
            }
        }

        public IEnumerable<Product> GetProducts(string search)
        {
            if (String.IsNullOrWhiteSpace(search))
            {
                return _context.Products.ToList();
            }
            search = search.Trim();

            return _context.Products.Where(x => x.Description.Contains(search)).ToList();
        }

        public void UpdateProduct(Product product) {
            _context.Products.Update(product);
            //_context.SaveChanges();
        }

        public bool ProductExists(Guid productId) {
            if(_context.Products.Find(productId) == null)
            {
                return false;
            }
            else
            {
                return true ;
            }
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
