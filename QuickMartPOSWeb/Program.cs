using Microsoft.EntityFrameworkCore;
using QuickMartPOSWeb.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the DbContext
var connectionString = builder.Configuration.GetConnectionString("QuickMartDatabase");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'QuickMartDatabase' not found.");
}
builder.Services.AddDbContext<QuickMartContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("QuickMartDatabase")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=POS}/{action=POSInterface}/{id?}");

app.Run();
