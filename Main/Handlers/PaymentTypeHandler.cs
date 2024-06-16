using Main.ContextDb;
using Main.Models;

namespace Main.Handlers;

internal class PaymentTypeHandler : BaseTableHandler<PaymentType>
{
    public PaymentTypeHandler(MainDbContext dbContext) : base(dbContext)
    {
    }
}
