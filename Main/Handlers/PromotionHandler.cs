using Main.ContextDb;
using System;
using Main.Interfaces;
using Main.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Main.Handlers;

internal class PromotionHandler : ITableHandler<Promotion>
{
    public string ViewDetailsName => "promotionViewDetail";

    public string TableName => "Акции";

    public string ViewTableName => "promotionsTable";

    private IReadOnlyCollection<Promotion> _promotions;
    private readonly MainDbContext dbContext;

    public PromotionHandler(MainDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Task<object> GetLists()
    {
        return Task.FromResult((object)new {});
    }

    public async Task LoadData()
    {
        _promotions ??= await dbContext.Promotion.ToListAsync();
    }

    public IReadOnlyCollection<Promotion> GetData()
    {
        return _promotions;
    }

}
