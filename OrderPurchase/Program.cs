

using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OrderPurchase.Sale.Application.Internal.CommandServices;
using OrderPurchase.Sale.Application.Internal.QueryServices;
using OrderPurchase.Sale.Domain.Repositories;
using OrderPurchase.Sale.Domain.Services;
using OrderPurchase.Sale.Infrastructure.Persistence.EFC.Repositories;
using OrderPurchase.Shared.Domain.Repositories;
using OrderPurchase.Shared.Infrastructure.Interfaces.ASP.Configuration;
using OrderPurchase.Shared.Infrastructure.Persistence.EFC.Configuration;
using OrderPurchase.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()))
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
    }
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo()
            {
                Title = "Positive.API",
                Version = "v1",
                Description = "Positive API for Insurance Policies",
                TermsOfService = new Uri("https://acme-learning.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "ACME Studios",
                    Email = "contact@acme.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
    });

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IOrderQueryService, OrderQueryService>();

builder.Services.AddScoped<IOrderCommandService, OrderCommandService>();
var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();