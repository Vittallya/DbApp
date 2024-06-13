using Main.Models;
using Microsoft.EntityFrameworkCore;

namespace Main.ContextDb;

public class MainDbContext(DbContextOptions<MainDbContext> options) : DbContext(options)
{
    public DbSet<Promotion> Promotion { get; set; }
}
