using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using System.Runtime;
using TestApp1.Dto;
using TestApp1.Service;
using TestAppDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using TestAppDataAccess.Repository;
using TestAppServices.UserService;

var builder = WebApplication.CreateBuilder (new WebApplicationOptions { 
   Args=args,
   ContentRootPath=Directory.GetCurrentDirectory()  
});

var connectionString = builder.Configuration.GetSection("DefaultConnectionString:default").Value;
//Add Database Service
builder.Services.AddDbContext<TestAppDBContext>(option =>
{
    option.UseSqlServer(connectionString);
});
// Add services to the container.
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IGeneratePdfService, GeneratePdfService>(); 
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddAutoMapper(typeof(UserService));
builder.Services.AddTransient<IUserService, UserService>();
//builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("setting"));
AppSettings settings = builder.Configuration.GetSection("setting").Get<AppSettings>();
builder.Services.AddSingleton(settings);
builder.Services.AddSwaggerGen(c=> {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test App-1", Version = "v1" });
    c.AddSecurityDefinition("x-api-key", new OpenApiSecurityScheme
    {
        Description =
            "JWT Authorization header using the x-api-key scheme. \r\n\r\n Enter key \"adfadfasdfasdfasdf\".\r\n\r\nExample: \"adfadfasdfasdfasdf\"",
        Name = "x-api-key",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "x-api-key"
                            },
                            Scheme = "Jwt",
                            Name = "x-api-key",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
});
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
    Path.Combine(builder.Environment.ContentRootPath, "pdf")),
    RequestPath = "/resources"
});
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test App-1");
});
app.MapControllers();

app.Run();
