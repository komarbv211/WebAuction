using Core.Interfaces;
using Core.MapperProfiles;
using Core.Services;
using Data.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using WebAuction.Services;
using Microsoft.AspNetCore.Identity;
using Data.Entities;
using WebAuction.SeedExtensions;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAutoMapper(typeof(AppProfile));

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<AuctionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultTokenProviders()
     .AddDefaultUI()
    .AddEntityFrameworkStores<AuctionDbContext>();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<FavoriteServices>();

builder.Services.AddScoped<IFilesService, FilesService>();
builder.Services.AddScoped<IBidService, BidService>();

builder.Services.AddScoped<ILotService, LotService>();

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IEmailSender, EmailService>();

builder.Services.AddScoped<IViewRender, ViewRender>();
// Реєстрація фонових завдань
builder.Services.AddHostedService<AuctionBackgroundService>();

var app = builder.Build();

// -------------- Seed Initial Data
using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.SeedRoles().Wait();
    scope.ServiceProvider.SeedAdmin().Wait();

}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
