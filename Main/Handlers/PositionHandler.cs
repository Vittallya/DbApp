using Main.ContextDb;
using Main.Models;
using System;

namespace Main.Handlers;

class PositionHandler(MainDbContext dbContext) : BaseTableHandler<Position>(dbContext)
{
}
