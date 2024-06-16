using Main.ContextDb;
using Main.Models;

namespace Main.Handlers;

internal class VenueHandler(MainDbContext dbContext) : BaseTableHandler<Venue>(dbContext)
{
}
