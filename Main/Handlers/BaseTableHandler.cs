using Main.ContextDb;
using Main.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Handlers;

internal abstract class BaseTableHandler<T> : ITableHandler<T>
    where T: class
{

    protected readonly MainDbContext _dbContext;
    protected IReadOnlyCollection<T> _data;

    public BaseTableHandler(MainDbContext dbContext)
    {
        this._dbContext = dbContext;
        ViewDetailsName = 
            typeof(T).Name.ToLower() + "DetailsView";
        ViewTableName =
            typeof(T).Name.ToLower() + "TableView";

        var attribute = typeof(T)
            .CustomAttributes
            .FirstOrDefault(attr => attr.AttributeType == typeof(TableAttribute));

        if(attribute != null)
        {
            TableName = attribute.ConstructorArguments[0].Value.ToString();
        }
    }

    public virtual string ViewDetailsName { get; } = typeof(T).Name;

    public virtual string ViewTableName { get; }

    public virtual string TableName { get; }

    public IReadOnlyCollection<T> GetData() => _data;

    public async Task LoadData()
    {
        _data = await LoadDataProtected();
    }
    public virtual Task<object> GetLists()
    {
        return Task.FromResult((object)new { });
    }

    public virtual T GetDefault() => Activator.CreateInstance<T>();

    protected virtual async Task<IReadOnlyCollection<T>> LoadDataProtected()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }
}
