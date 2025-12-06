using System.Text;
using Cortex.Mediator.Commands;
using Cortex.Mediator.DependencyInjection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using PrimeFixPlatform.API.AutorepairCatalog.Application.Internal.CommandServices;
using PrimeFixPlatform.API.AutorepairCatalog.Application.Internal.OutboundServices.ACL;
using PrimeFixPlatform.API.AutorepairCatalog.Application.Internal.OutboundServices.ACL.Services;
using PrimeFixPlatform.API.AutorepairCatalog.Application.Internal.QueryServices;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Repositories;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Services;
using PrimeFixPlatform.API.AutorepairCatalog.Infrastructure.Persistence.EFC.Repositories;
using PrimeFixPlatform.API.AutorepairCatalog.Interfaces.ACL;
using PrimeFixPlatform.API.AutorepairCatalog.Interfaces.ACL.Services;
using PrimeFixPlatform.API.AutorepairRegister.Application.Internal.CommandServices;
using PrimeFixPlatform.API.AutorepairRegister.Application.Internal.OutboundServices;
using PrimeFixPlatform.API.AutorepairRegister.Application.Internal.OutboundServices.Services;
using PrimeFixPlatform.API.AutorepairRegister.Application.Internal.QueryServices;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Repositories;
using PrimeFixPlatform.API.AutorepairRegister.Domain.Services;
using PrimeFixPlatform.API.AutorepairRegister.Infrastructure.Persistence.EFC.Repositories;
using PrimeFixPlatform.API.CollectionDiagnosis.Application.Internal.CommandServices;
using PrimeFixPlatform.API.CollectionDiagnosis.Application.Internal.QueryServices;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Repositories;
using PrimeFixPlatform.API.CollectionDiagnosis.Domain.Services;
using PrimeFixPlatform.API.CollectionDiagnosis.Infrastructure.Persistence.EFC.Repositories;
using PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.ACL;
using PrimeFixPlatform.API.CollectionDiagnosis.Interfaces.ACL.Services;
using PrimeFixPlatform.API.Iam.Application.Internal.CommandServices;
using PrimeFixPlatform.API.IAM.Application.Internal.CommandServices;
using PrimeFixPlatform.API.IAM.Application.Internal.EventHandlers;
using PrimeFixPlatform.API.IAM.Application.Internal.OutboundServices.ACL;
using PrimeFixPlatform.API.IAM.Application.Internal.OutboundServices.ACL.Services;
using PrimeFixPlatform.API.IAM.Application.Internal.OutboundServices.Hashing;
using PrimeFixPlatform.API.IAM.Application.Internal.OutboundServices.Tokens;
using PrimeFixPlatform.API.Iam.Application.Internal.QueryServices;
using PrimeFixPlatform.API.IAM.Application.Internal.QueryServices;
using PrimeFixPlatform.API.Iam.Domain.Repositories;
using PrimeFixPlatform.API.IAM.Domain.Repositories;
using PrimeFixPlatform.API.Iam.Domain.Services;
using PrimeFixPlatform.API.IAM.Domain.Services;
using PrimeFixPlatform.API.IAM.Infrastructure.Hashing.BCrypt.Services;
using PrimeFixPlatform.API.Iam.Infrastructure.Persistence.EFC.Repositories;
using PrimeFixPlatform.API.IAM.Infrastructure.Persistence.EFC.Repositories;
using PrimeFixPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Components;
using PrimeFixPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using PrimeFixPlatform.API.IAM.Infrastructure.Tokens.JWT.Configuration;
using PrimeFixPlatform.API.IAM.Infrastructure.Tokens.JWT.Services;
using PrimeFixPlatform.API.IAM.Interfaces.ACL;
using PrimeFixPlatform.API.IAM.Interfaces.ACL.Services;
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
using PrimeFixPlatform.API.PaymentService.Interfaces.ACL;
using PrimeFixPlatform.API.PaymentService.Interfaces.ACL.Services;
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
            .AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(_ => true));
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
    // Set the comments path for the Swagger JSON and UI.
    options.AddServer(new OpenApiServer { Url = "/" });
    // Define the BearerAuth scheme that's in use
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    // Add a global security requirement for BearerAuth
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
    // Enable Swagger Annotations
    options.EnableAnnotations();
});

// Dependency Injection 

// Shared Bounded Context
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// TokenSettings Configuration
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

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
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationCommandService, LocationCommandService>();
builder.Services.AddScoped<ILocationQueryService, LocationQueryService>();
builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();
builder.Services.AddScoped<IMembershipCommandService, MembershipCommandService>();
builder.Services.AddScoped<IMembershipQueryService, MembershipQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();

// IAM Facade Services
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

// IAM Outbound Services
builder.Services.AddScoped<IExternalPaymentServiceFromIam, ExternalPaymentServiceFromIam>();
builder.Services.AddScoped<IExternalAutoRepairCatalogServiceFromIam, ExternalAutoRepairCatalogServiceFromIam>();

// AutoRepair Register Bounded Context
builder.Services.AddScoped<ITechnicianRepository, TechnicianRepository>();
builder.Services.AddScoped<ITechnicianCommandService, TechnicianCommandService>();
builder.Services.AddScoped<ITechnicianQueryService, TechnicianQueryService>();
builder.Services.AddScoped<ITechnicianScheduleRepository, TechnicianScheduleRepository>();
builder.Services.AddScoped<ITechnicianScheduleCommandService, TechnicianScheduleCommandService>();
builder.Services.AddScoped<ITechnicianScheduleQueryService, TechnicianScheduleQueryService>();

// AutoRepair Register Outbound Services
builder.Services.AddScoped<IExternalAutoRepairCatalogServiceFromAutoRepairRegister, ExternalAutoRepairCatalogServiceFromAutoRepairRegister>();

// AutoRepair Catalog Bounded Context
builder.Services.AddScoped<IAutoRepairRepository, AutoRepairRepository>();
builder.Services.AddScoped<IAutoRepairCommandService, AutoRepairCommandService>();
builder.Services.AddScoped<IAutoRepairQueryService, AutoRepairQueryService>();

// AutoRepair Catalog Facade Services
builder.Services.AddScoped<IAutoRepairCatalogContextFacade, AutoRepairCatalogContextFacade>();

// AutoRepair Catalog Outbound Services
builder.Services.AddScoped<IExternalIamServiceFromAutoRepairCatalog, ExternalIamServiceFromAutoRepairCatalog>();

// Collection Diagnosis Bounded Context
builder.Services.AddScoped<IDiagnosticRepository, DiagnosticRepository>();
builder.Services.AddScoped<IDiagnosticCommandService, DiagnosticCommandService>();
builder.Services.AddScoped<IDiagnosticQueryService, DiagnosticQueryService>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceCommandService, ServiceCommandService>();
builder.Services.AddScoped<IServiceQueryService, ServiceQueryService>();
builder.Services.AddScoped<IVisitRepository, VisitRepository>();
builder.Services.AddScoped<IVisitCommandService, VisitCommandService>();
builder.Services.AddScoped<IVisitQueryService, VisitQueryService>();
builder.Services.AddScoped<IExpectedVisitRepository, ExpectedVisitRepository>();

// Collection Diagnosis Facade Services
builder.Services.AddScoped<ICollectionDiagnosisContextFacade, CollectionDiagnosisContextFacade>();

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


// Payment Service Facade Services
builder.Services.AddScoped<IPaymentServiceContextFacade, PaymentServiceContextFacade>();

// JWT Authentication Configuration
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = "JwtBearer";
        options.DefaultChallengeScheme = "JwtBearer";
    })
    .AddJwtBearer("JwtBearer", options =>
    {
        var tokenSettings = builder.Configuration
                                .GetSection("TokenSettings")
                                .Get<TokenSettings>()
                            ?? throw new InvalidOperationException("TokenSettings section is missing in configuration.");
        
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = tokenSettings.Issuer,
            ValidateAudience = true,
            ValidAudience = tokenSettings.Audience,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret))
        };
    });

// Application Startup Service
builder.Services.AddHostedService<ApplicationStartupService>();

// Mediator Configuration
// Add Logging Behavior to all commands
builder.Services.AddScoped(typeof(ICommandPipelineBehavior<>), typeof(LoggingCommandBehavior<>));
builder.Services.AddCortexMediator(
    configuration: builder.Configuration,
    handlerAssemblyMarkerTypes: [typeof(Program)], configure: options =>
    {
        options.AddOpenCommandPipelineBehavior(typeof(LoggingCommandBehavior<>));
    });

// Forwarded Headers Configuration
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

var app = builder.Build();

// Apply migrations always (Production & Development)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated(); // In the future use migrations
}

// Configure the HTTP request pipeline.
app.UseForwardedHeaders();

// Global exception handler
app.UseExceptionHandler();

// Enable CORS
app.UseCors("AllowAllPolicy");

// Swagger
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "PrimeFixPlatform API v1");
    options.DocumentTitle = "PrimeFixPlatform API Docs";
    options.RoutePrefix = "swagger";
    
    // Configure supported HTTP methods for "Try it out"
    options.SupportedSubmitMethods(new[]
    {
        Swashbuckle.AspNetCore.SwaggerUI.SubmitMethod.Get,
        Swashbuckle.AspNetCore.SwaggerUI.SubmitMethod.Post,
        Swashbuckle.AspNetCore.SwaggerUI.SubmitMethod.Put,
        Swashbuckle.AspNetCore.SwaggerUI.SubmitMethod.Delete,
        Swashbuckle.AspNetCore.SwaggerUI.SubmitMethod.Patch
    });
    
    // Enable "Try it out" by default
    options.EnableTryItOutByDefault();
});

// Only redirect HTTPS in local
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseRouting();

// Custom Request Authorization Middleware
app.UseMiddleware<RequestAuthorizationMiddleware>();
// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Health check
app.MapGet("/health", () => Results.Ok("Healthy"));

app.Run();