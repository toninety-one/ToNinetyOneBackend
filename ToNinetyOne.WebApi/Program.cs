using System.Reflection;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config;
using ToNinetyOne.Config.Common.Mappings;
using ToNinetyOne.Config.Static;
using ToNinetyOne.Identity.Interfaces;
using ToNinetyOne.IdentityDomain;
using ToNinetyOne.IdentityPersistence;
using ToNinetyOne.Persistence;
using ToNinetyOne.Utils;
using ToNinetyOne.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IToNinetyOneDbContext).Assembly));
    config.AddProfile(new AssemblyMappingProfile(typeof(IToNinetyOneUserDbContext).Assembly));
});

builder.Services.AddApplication();

builder.Services.AddPersistence(builder.Configuration, builder.Environment.IsDevelopment());

builder.Services.AddUserPersistence(builder.Configuration, builder.Environment.IsDevelopment());

builder.Services.AddControllers();

var jwtSetting = builder.Configuration.GetSection("JwtSettings");

builder.Services.Configure<JwtSetting>(jwtSetting);

var authKey = builder.Configuration.GetValue<string>("JwtSettings:SecurityKey");

if (authKey == null)
{
    Console.WriteLine("missing auth key");
    return;
}

builder.Services.AddAuthorization(options =>
{
    foreach (var role in Roles.Fields)
        options.AddPolicy(role,
            policy => { policy.RequireClaim(ClaimTypes.Role, role); });
});

builder.Services.AddAuthentication(item =>
{
    item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(item =>
{
    item.RequireHttpsMetadata = true;
    item.SaveToken = true;

    item.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authKey)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Demo API",
        Version = "v1"
    });
    option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();

    app.UseSwaggerUI(config =>
    {
        config.RoutePrefix = string.Empty;
        config.DocumentTitle = "ToNinetyOne Web Api";
        config.SwaggerEndpoint("swagger/v1/swagger.json", "ToNinetyOne API");
    });
// }

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseStaticFiles();

if (!Directory.Exists(DownloadFile.FilesDirectory))
{
    Directory.CreateDirectory(DownloadFile.FilesDirectory);
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), DownloadFile.FilesDirectory)),
    RequestPath = $"/{DownloadFile.FilesDirectory}"
});

app.UseAuthentication();

app.UseAuthorization();

app.UseCors(b => b
    .WithOrigins("http://localhost:80")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
);

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    try
    {
        var userContext = serviceProvider.GetService<ToNinetyOneUserDbContext>();

        var adminId = UserDbInitializer.Initialize(userContext ?? throw new NullReferenceException(nameof(userContext)), authKey);
        
        var context = serviceProvider.GetService<ToNinetyOneDbContext>();

        DbInitializer.Initialize(context ?? throw new NullReferenceException(nameof(context)), adminId);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
}

app.Run();