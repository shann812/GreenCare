using GreenCareApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;


public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
    {
	}

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
}
