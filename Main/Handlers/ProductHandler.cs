using Main.ContextDb;
using Main.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Main.Handlers
{
    internal class ProductHandler(MainDbContext dbContext) : BaseTableHandler<Product>(dbContext)
    {
        protected override async Task<IReadOnlyCollection<Product>> LoadDataProtected()
        {
            return await _dbContext
                .Products
                .Include("ProductType")
                .ToListAsync();
        }

        public override async Task<object> GetLists()
        {
            var productTypes = await _dbContext.ProductTypes.ToListAsync();
            return new
            {
                productTypes
            };
        }
    }
}
