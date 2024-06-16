using Main.ContextDb;
using Main.Models;

namespace Main.Handlers;

internal class PromotionHandler(MainDbContext dbContext) : BaseTableHandler<Promotion>(dbContext)
{
}
