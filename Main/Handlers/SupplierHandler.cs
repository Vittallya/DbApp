using Main.ContextDb;
using Main.Models;

namespace Main.Handlers;

internal class SupplierHandler(MainDbContext dbContext) : BaseTableHandler<Supplier>(dbContext)
{
}
