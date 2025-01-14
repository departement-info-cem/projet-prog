using LapinCouvertModels.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

const bool useSqlite = true;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString;
if (!useSqlite)
{
    connectionString = builder.Configuration.GetConnectionString("SqliteConnection") ??
                       throw new InvalidOperationException("Connection string 'SqliteConnection' not found.");
    builder.Services.AddDbContext<LapinCouvertContext>(options =>
    {
        options.UseSqlServer(connectionString);
        options.UseLazyLoadingProxies();
    });
}
else
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    builder.Services.AddDbContext<LapinCouvertContext>(options =>
    {
        options.UseSqlite(connectionString);
        options.UseLazyLoadingProxies();
    });
}

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LapinCouvertContext>();

builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();