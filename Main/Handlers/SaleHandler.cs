using Main.ContextDb;
using Main.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Main.Handlers;

internal class SaleHandler(MainDbContext dbContext) : BaseTableHandler<Sale>(dbContext)
{
    public override async Task<object> GetLists()
    {
        var products = await _dbContext.Products.ToListAsync();
        var venues = await _dbContext.Venues.ToListAsync();
        var employees = await _dbContext.Employees.ToListAsync();
        var paymentTypes = await _dbContext.PaymentTypes.ToListAsync();
        var promotions = await _dbContext.Promotion.ToListAsync();

        return new
        {
            products, venues, employees, paymentTypes, promotions
        };
    }

    protected override async Task<IReadOnlyCollection<Sale>> LoadDataProtected()
    {
        return await _dbContext
            .Set<Sale>()
            .Include("Product")
            .Include("PaymentType")
            .Include("Employee")
            .Include("Promotion")
            .Include("Venue")
            .ToListAsync();
    }
}
