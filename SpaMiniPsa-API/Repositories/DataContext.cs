using Microsoft.EntityFrameworkCore;
using SpaMiniPsa_API.Entities;
using SpaMiniPsa_API.Repositories;

namespace SpaMiniPsa_API.Repositories;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }

    public DbSet<Dog> dogs { get; set; }
}
