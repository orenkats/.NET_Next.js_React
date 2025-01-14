using Microsoft.EntityFrameworkCore;
using UserApi.Domain.Entities;

namespace UserApi.Infrastructure.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}
