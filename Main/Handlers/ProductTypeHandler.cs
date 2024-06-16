using Main.ContextDb;
using Main.Models;

namespace Main.Handlers;

internal class ProductTypeHandler : BaseTableHandler<ProductType>
{
    public ProductTypeHandler(MainDbContext dbContext) : base(dbContext)
    {
    }
}
