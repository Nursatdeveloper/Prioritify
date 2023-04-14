using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Prioritify.Data.DbContexts;
using Prioritify.Data.Repositories;
using Prioritify.Data.Repositories.Base;
using Prioritify.Data.Tables;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContexts
var connection = builder.Configuration.GetConnectionString("dbConnection");
builder.Services.AddDbContext<SystemDbContext>(options => options.UseNpgsql(connection));
builder.Services.AddDbContext<UserDbContext>(options => options.UseNpgsql(connection));
builder.Services.AddDbContext<PrioritifyDbContext>(options => options.UseNpgsql(connection));

// Add Repositories
builder.Services.AddSystemRepositories();
builder.Services.AddUserRepositories();

// System Repositories
builder.Services.AddScoped<ISystemRepository<TbExceptions>, SystemRepository<TbExceptions>>();
builder.Services.AddScoped<ISystemRepository<TbLogs>, SystemRepository<TbLogs>>();
builder.Services.AddScoped<IRepositoryAccessor, RepositoryAccessor>();
builder.Services.AddScoped<IPrioritifyRepository<TbTasks>, PrioritifyRepository<TbTasks>>();

builder.Services.AddDbContext<TestDbContext>(options => options.UseNpgsql(connection));
builder.Services.AddScoped<IRepositoryBase<TestDbContext, TbTest>, RepositoryBase<TestDbContext, TbTest>>();

// Authentication/Authorization
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => {
    options.Cookie.Name = "PrioritifyAuthCookie";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.LoginPath = "/User/Login";
});

builder.Services.AddAuthorization(options => {
    options.AddPolicy("OnlyUsers", policy => policy.RequireClaim("Account", "Exist"));
    options.AddPolicy("OnlyAdmins", policy => policy.RequireClaim("IsAdmin", "True"));
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
