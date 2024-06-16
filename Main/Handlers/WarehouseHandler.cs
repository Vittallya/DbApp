using Main.ContextDb;
using Main.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Main.Handlers;

internal class WarehouseHandler(MainDbContext dbContext) : BaseTableHandler<Warehouse>(dbContext)
{
    public override async Task<object> GetLists()
    {
        var products = await _dbContext.Products.ToListAsync();
        var suppliers = await _dbContext.Suppliers.ToListAsync();
        var venues = await _dbContext.Venues.ToListAsync();

        return new
        {
            products, suppliers, venues
        };
    }

    protected override async Task<IReadOnlyCollection<Warehouse>> LoadDataProtected()
    {
        return await _dbContext
            .Warehouses
            .Include("Venue")
            .Include("Product")
            .Include("Supplier")
            .ToListAsync();
    }
}
