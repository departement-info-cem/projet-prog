using LapinCouvertModels.Models;
using Microsoft.AspNetCore.Identity;

namespace LapinCouvertModels.Data;

public static class Seed
{
    public static IdentityUser[] SeedUsers()
    {
        PasswordHasher<IdentityUser>? hasher = new();
        IdentityUser admin = new()
        {
            Id = "11111111-1111-1111-1111-111111111111",
            UserName = "admin@admin.com",
            Email = "admin@admin.com",
            // La comparaison d'identity se fait avec les versions normalisés
            NormalizedEmail = "ADMIN@ADMIN.COM",
            NormalizedUserName = "ADMIN@ADMIN.COM",
            EmailConfirmed = true,
            // On encrypte le mot de passe
            PasswordHash = hasher.HashPassword(null, "Passw0rd!"),
            LockoutEnabled = true
        };

        return [admin];
    }

    public static IdentityRole[] SeedRoles()
    {
        IdentityRole adminRole = new()
        {
            Id = "11111111-1111-1111-1111-111111111112",
            Name = LapinCouvertContext.ADMIN_ROLE,
            NormalizedName = LapinCouvertContext.ADMIN_ROLE.ToUpper()
        };

        return [adminRole];
    }

    public static IdentityUserRole<string>[] SeedUserRoles()
    {
        IdentityUserRole<string> userAdmin = new()
        {
            RoleId = "11111111-1111-1111-1111-111111111112",
            UserId = "11111111-1111-1111-1111-111111111111"
        };
        return [userAdmin];
    }

    public static MenuItem[] SeedMenuItems()
    {
        return
        [
            new MenuItem
            {
                Id = 1,
                Name = "Pogo",
                Price = 2.00f,
                Quantity = 10,
                ImageUrl = "https://lamilanaise.com/wp-content/uploads/2024/02/pogo-2.png"
            },
            new MenuItem
            {
                Id = 2,
                Name = "Coke",
                Price = 1.00f,
                Quantity = 5,
                ImageUrl = "https://fruitsuite.ca/cdn/shop/files/shutterstock_193222430-2_01f2dedd-e84e-4681-8e6b-1add31871a78.webp?v=1717432789&height=200"
            },
            new MenuItem
            {
                Id = 3,
                Name = "7up",
                Price = 1.00f,
                Quantity = 8,
                ImageUrl = "https://i5.walmartimages.com/asr/9aed7ff8-1882-4b38-b937-cbc4cc3e16cd.077a7aa52b2bacda88cee393b0446946.jpeg?odnHeight=200&odnWidth=200&odnBg=FFFFFF"
            },
            new MenuItem
            {
                Id = 4,
                Name = "Pizza Pochette",
                Price = 2.00f,
                Quantity = 5,
                ImageUrl = "https://klopelgag.com/wp-content/uploads/2020/01/pizzapochette.png"
            },
            new MenuItem
            {
                Id = 5,
                Name = "Ramen",
                Price = 2.00f,
                Quantity = 0,
                ImageUrl = "https://kabayanstore.eu/cdn/shop/files/IMG-4467.png?v=1716212876&height=250"
            },
        ];
    }
}