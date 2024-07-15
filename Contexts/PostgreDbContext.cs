using BasicRestAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicRestAPI.Contexts;

public class PostgreDbContext : DbContext
{
    public PostgreDbContext(DbContextOptions<PostgreDbContext> options) : base(options)
    {
        
    }
    public DbSet<Computer> Computers { get; set; }
}
