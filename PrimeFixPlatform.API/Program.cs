using Cortex.Mediator.Commands;
using Cortex.Mediator.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Any;
using PrimeFixPlatform.API.AutorepairCatalog.Application.Internal.CommandServices;
using PrimeFixPlatform.API.AutorepairCatalog.Application.Internal.QueryServices;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Repositories;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Services;
using PrimeFixPlatform.API.AutorepairCatalog.Infrastructure.Persistence.EFC.Repositories;
using PrimeFixPlatform.API.AutorepairRegister.Application.Internal.CommandServices;
using PrimeFixPlatform.API.AutorepairRegister.Application.Internal.QueryServices;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Repositories;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Services;
using PrimeFixPlatform.API.AutorepairRegister.Infrastructure.Persistence.EFC.Repositories;
using PrimeFixPlatform.API.Iam.Application.Internal.CommandServices;
using PrimeFixPlatform.API.Iam.Application.Internal.QueryServices;
using PrimeFixPlatform.API.Iam.Domain.Repositories;
using PrimeFixPlatform.API.Iam.Domain.Services;
using PrimeFixPlatform.API.Iam.Infrastructure.Persistence.EFC.Repositories;
using PrimeFixPlatform.API.MaintenanceTracking.Application.Internal.CommandServices;
using PrimeFixPlatform.API.MaintenanceTracking.Application.Internal.QueryServices;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Repositories;
using PrimeFixPlatform.API.MaintenanceTracking.Domain.Services;
using PrimeFixPlatform.API.MaintenanceTracking.Infrastructure.Persistence.EFC.Repositories;
using PrimeFixPlatform.API.PaymentService.Application.Internal.CommandServices;
using PrimeFixPlatform.API.PaymentService.Application.Internal.QueryServices;
using PrimeFixPlatform.API.PaymentService.Domain.Repositories;
using PrimeFixPlatform.API.PaymentService.Domain.Services;
using PrimeFixPlatform.API.PaymentService.Infrastructure.Persistence.EFC.Repositories;
using PrimeFixPlatform.API.Shared.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Handlers;
using PrimeFixPlatform.API.Shared.Infrastructure.Mediator.Cortex.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Enforce lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add services to the container.
builder.Services.AddControllers(options =>
    {
        options.Conventions.Add(new KebabCaseRouteNamingConvention());
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
    });

// Global Exception Handling and Problem Details

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
// Customizing the response for invalid model state
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        // Extract validation errors from ModelState
        var errors = context.ModelState
            .Where(e => e.Value?.Errors.Count > 0)
            .ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value!.Errors.Select(err => err.ErrorMessage).ToArray()
            );

        var problemDetails = new ValidationProblemDetails(context.ModelState)
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "JSON validation failed",
            Detail = "One or more validation errors occurred.",
            Instance = context.HttpContext.Request.Path
        };
        // Add the errors dictionary to the Extensions property
        problemDetails.Extensions["errors"] = errors;
        return new BadRequestObjectResult(problemDetails);
    };
});

// DB Context Configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        options.UseNpgsql(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableDetailedErrors();
    }
    else
    {
        options.UseNpgsql(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
    }
});

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod().AllowAnyHeader());
});
    
// Swagger for API Documentation for development
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PrimeFixPlatform API",
        Version = "v1",
        Description = "Prime Fix Platform API",
        TermsOfService = new Uri("https://github.com/prime-fix-app-web/backend"),
        Contact = new OpenApiContact
        {
            Name = "PrimeFix Studios",
            Email = "contact@primefix.com"
        },
        License = new OpenApiLicense
        {
            Name = "Apache 2.0",
            Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
        }
    });

    options.MapType<TimeOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "time",
        Example = new OpenApiString("00:00:00")
    });
});

// Dependency Injection 

// Shared Bounded Context
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Iam Bounded Context
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<IUserAccountRepository, UserAccountRepository>();
builder.Services.AddScoped<IUserAccountCommandService, UserAccountCommandService>();
builder.Services.AddScoped<IUserAccountQueryService, UserAccountQueryService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleCommandService, RoleCommandService>();
builder.Services.AddScoped<IRoleQueryService, RoleQueryService>();
builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();
builder.Services.AddScoped<IMembershipCommandService, MembershipCommandService>();
builder.Services.AddScoped<IMembershipQueryService, MembershipQueryService>();

// AutoRepair Register Bounded Context
builder.Services.AddScoped<ITechnicianRepository, TechnicianRepository>();
builder.Services.AddScoped<ITechnicianCommandService, TechnicianCommandService>();
builder.Services.AddScoped<ITechnicianQueryService, TechnicianQueryService>();
builder.Services.AddScoped<ITechnicianScheduleRepository, TechnicianScheduleRepository>();
builder.Services.AddScoped<ITechnicianScheduleCommandService, TechnicianScheduleCommandService>();
builder.Services.AddScoped<ITechnicianScheduleQueryService, TechnicianScheduleQueryService>();

// AutoRepair Catalog Bounded Context
builder.Services.AddScoped<IAutoRepairRepository, AutoRepairRepository>();
builder.Services.AddScoped<IAutoRepairCommandService, AutoRepairCommandService>();
builder.Services.AddScoped<IAutoRepairQueryService, AutoRepairQueryService>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationCommandService, LocationCommandService>();
builder.Services.AddScoped<ILocationQueryService, LocationQueryService>();

// Maintenance Tracking Bounded Context
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleCommandService, VehicleCommandService>();
builder.Services.AddScoped<IVehicleQueryService, VehicleQueryService>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationCommandService, NotificationCommandService>();
builder.Services.AddScoped<INotificationQueryService, NotificationQueryService>();


// Payment Service Bounded Context
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentCommandService, PaymentCommandService>();
builder.Services.AddScoped<IPaymentQueryService, PaymentQueryService>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IRatingCommandService, RatingCommandService>();
builder.Services.AddScoped<IRatingQueryService, RatingQueryService>();


// Mediator Configuration
// Add Mediator Injection Configuration
builder.Services.AddScoped(typeof(ICommandPipelineBehavior<>), typeof(LoggingCommandBehavior<>));

// Add Cortex Mediator for Event Handling
builder.Services.AddCortexMediator(
    configuration: builder.Configuration,
    handlerAssemblyMarkerTypes: [typeof(Program)], configure: options =>
    {
        options.AddOpenCommandPipelineBehavior(typeof(LoggingCommandBehavior<>));
    });

var app = builder.Build();

// Database Initialization for Development
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

// Apply CORS Policy
app.UseCors("AllowAllPolicy");

// Enable Swagger in Development
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "PrimeFixPlatform API v1");
    options.DocumentTitle = "PrimeFixPlatform API Docs";
});

// Enforce HTTPS Redirection
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

// Health Check Endpoint
app.MapGet("/health", () => Results.Ok("Healthy"));

app.Run();