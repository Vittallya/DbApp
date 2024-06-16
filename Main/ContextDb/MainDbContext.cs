using Main.Models;
using Microsoft.EntityFrameworkCore;

namespace Main.ContextDb;

public class MainDbContext(DbContextOptions<MainDbContext> options) : DbContext(options)
{
    public DbSet<Promotion> Promotion { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Venue> Venues { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Shift> Shifts { get; set; }
    public DbSet<Sale> Sales { get; set; }
}
