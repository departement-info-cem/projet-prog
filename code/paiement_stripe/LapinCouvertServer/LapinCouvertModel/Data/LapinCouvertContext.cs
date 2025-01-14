using LapinCouvertModels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LapinCouvertModels.Data;

public class LapinCouvertContext(DbContextOptions<LapinCouvertContext> options) : IdentityDbContext(options)
{
    public const string ADMIN_ROLE = "admin";
    
    public DbSet<MenuItem> MenuItems { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<IdentityUser>().HasData(Seed.SeedUsers());
        builder.Entity<IdentityRole>().HasData(Seed.SeedRoles());
        builder.Entity<IdentityUserRole<string>>().HasData(Seed.SeedUserRoles());
        
        builder.Entity<MenuItem>().HasData(Seed.SeedMenuItems());
    }
}