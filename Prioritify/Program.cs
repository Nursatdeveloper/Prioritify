using Microsoft.EntityFrameworkCore;
using Prioritify.Data.DbContexts;
using Prioritify.Data.Repositories;
using Prioritify.Data.Tables;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContexts
var connection = builder.Configuration.GetConnectionString("dbConnection");
builder.Services.AddDbContext<SystemDbContext>(options => options.UseNpgsql(connection));

// Add Repositories
builder.Services.AddScoped<ISystemRepository<TbExceptions>, SystemRepository<TbExceptions>>();
builder.Services.AddScoped<ISystemRepository<TbLogs>, SystemRepository<TbLogs>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment()) {
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

app.Run();
