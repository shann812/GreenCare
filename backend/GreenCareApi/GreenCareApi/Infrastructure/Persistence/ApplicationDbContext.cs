using GreenCareApi.Domain.Entities;
using GreenCareApi.Domain.Entities.Flower;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
    {
	}

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    { 
        base.OnModelCreating(modelBuilder); 
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "User" }, 
            new Role { Id = 2, Name = "Admin" }
        );

        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany()
            .HasForeignKey(u => u.RoleId);

        modelBuilder.Entity<FlowerBase>()
            .HasDiscriminator<string>("FlowerKind")
            .HasValue<OfficialFlower>("Official")
            .HasValue<UserFlower>("User");

        modelBuilder.Entity<UserFlower>()
            .HasOne(f => f.Creator)
            .WithMany()
            .HasForeignKey(f => f.CreatorId);
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<FlowerBase> Flowers => Set<FlowerBase>();
}
