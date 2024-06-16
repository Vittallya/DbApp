using Main.ContextDb;
using Main.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Main.Handlers;

internal class ShiftHandler(MainDbContext dbContext) : BaseTableHandler<Shift>(dbContext)
{
    public override async Task<object> GetLists()
    {
        var employees = await _dbContext.Employees.ToListAsync();
        return new
        {
            employees
        };
    }

    protected override async Task<IReadOnlyCollection<Shift>> LoadDataProtected()
    {
        return await _dbContext.Shifts.Include("Employee").ToListAsync();
    }
}
