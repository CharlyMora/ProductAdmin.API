using ProductAdmin.API.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAdmin.API.Services
{
    public class ProductAdminRepository: IProductsAdminRepository, IDisposable
    {
        private readonly ProductsAdminContext _context;

        public ProductAdminRepository(ProductsAdminContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
