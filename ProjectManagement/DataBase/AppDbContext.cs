using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjectManagement.Features.Users;

namespace ProjectManagement.DataBase;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options):base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
}