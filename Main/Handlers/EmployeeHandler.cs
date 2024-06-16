using Main.ContextDb;
using Main.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Main.Handlers;

internal class EmployeeHandler(MainDbContext dbContext) : BaseTableHandler<Employee>(dbContext)
{
    public override async Task<object> GetLists()
    {
        var positions = await _dbContext.Positions.ToListAsync();
        var venues = await _dbContext.Venues.ToListAsync();
        return new
        {
            positions,
            venues
        };
    }

    protected override async Task<IReadOnlyCollection<Employee>> LoadDataProtected()
    {
        return await _dbContext
            .Employees
            .Include("Venue")
            .Include("Position")
            .ToListAsync();
    }
}
