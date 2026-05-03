using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RoadmApp.Application.IServices;
using RoadmApp.Application.Services;
using RoadmApp.Application.UseCases.Access;
using RoadmApp.Application.UseCases.Access.CreateAccess;
using RoadmApp.Application.UseCases.Access.FirstAccess;
using RoadmApp.Domain.IRepositories;
using RoadmApp.Domain.Services;
using RoadmApp.Infrastructure.Data;
using RoadmApp.Infrastructure.Repositories;
using System.Text;

try
{
    var builder = WebApplication.CreateBuilder(args);


    builder.Services.AddEndpointsApiExplorer();

    // Configure o Swagger assim:
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "RoadmApp API",
            Version = "v1",
            Description = "API do sistema RoadmApp"
        });

        // Configuração do JWT
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Insira o token JWT no formato: Bearer {seu token}"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
    });


    builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("Data Source=RoadmApp.db"));

    var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);

    #region Services 

    builder.Services.AddScoped<ILogService, LogService>();
    builder.Services.AddScoped<IAuthService, AuthService>();
    builder.Services.AddScoped<IEmailService, EmailService>();
    builder.Services.AddScoped<ITokenService, TokenService>();
    builder.Services.AddScoped<IFirstAccessUseCase, FirstAccessUseCase>();
    builder.Services.AddScoped<ICreateAccessUseCase, CreateAccessUseCase>();
    builder.Services.AddScoped<IPasswordResetService, PasswordResetService>();
    #endregion

    #region  Repositories 

    builder.Services.AddScoped<ILogRepository, LogRepository>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<ITokenRepository, TokenRepository>();
    builder.Services.AddScoped<IEmailRepository, EmailRepository>();
    builder.Services.AddScoped<IAccessRepository, AccessRepository>();
    builder.Services.AddScoped<IContactRepository, ContactRepository>();
    builder.Services.AddScoped<IPasswordResetRepository, PasswordResetRepository>();
    #endregion


    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

    builder.Services.AddAuthorization();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();

    var app = builder.Build();


    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.EnsureCreated();
    }
     
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "RoadmApp API v1");
            c.RoutePrefix = "swagger"; 
        });
    }

    app.UseAuthentication();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"ERRO: {ex.Message}");
    Console.WriteLine(ex.StackTrace);
    throw;
}