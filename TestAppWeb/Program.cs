using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TestAppDataAccess;
using TestAppDataAccess.Repository;
using TestAppServices.EmailService;
using TestAppServices.UserService;
using TestAppServices.UserService.Dto;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetSection("DefaultConnectionString:default").Value;
builder.Services.AddDbContext<TestAppDBContext>(option =>
{
    option.UseSqlServer(connectionString);
});
EmailSettings settings = builder.Configuration.GetSection("EmailSettings").Get<EmailSettings>();
builder.Services.AddSingleton(settings);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddAutoMapper(typeof(UserService));
builder.Services.AddTransient<IUserService,UserService>();
builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
