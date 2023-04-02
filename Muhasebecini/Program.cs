using Microsoft.EntityFrameworkCore;
using Muhasebecini.Entities;
using Muhasebecini.Seeds;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region Db
var connectionString = builder.Configuration.GetConnectionString("MsSQLConnection");

builder.Services.AddDbContext<DatabaseContext>(x => x.UseSqlServer(connectionString));
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseBrowserLink();
}

try { DataSeeds.Seed(app); }
catch (Exception ex) { }



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
