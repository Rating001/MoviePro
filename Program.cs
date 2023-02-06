using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoviePro.Data;
using MoviePro.Helpers;
using MoviePro.Models.Settings;
using MoviePro.Services.Interfaces;
using MoviePro.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var connectionString = builder.Configuration.GetSection("pgSettings")["pgConnection"];
//var connectionString = ConnectionHelper.GetConnectionString(builder.Configuration);
var appSettings = builder.Configuration.GetSection("AppSettings");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(ConnectionHelper.GetConnectionString(builder.Configuration)));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

//Seed the database
builder.Services.AddTransient<SeedService>();

builder.Services.AddControllersWithViews();

builder.Services.Configure<AppSettings>(appSettings);
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IDataMappingService, DataMappingService>();
builder.Services.AddScoped<IRemoteMovieService, RemoteMovieService>();

var app = builder.Build();

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

var dataService = app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedService>();

dataService.ManageDataAsync().Wait();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
