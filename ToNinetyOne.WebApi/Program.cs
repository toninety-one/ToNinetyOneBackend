using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ToNinetyOne.Application;
using ToNinetyOne.Application.Common.Mappings;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Persistence;
using ToNinetyOne.UserPersistence;
using ToNinetyOne.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IToNinetyOneDbContext).Assembly));
});

builder.Services.AddApplication();


builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddUserPersistence(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("http://localhost:3000");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer("Bearer", options =>
{
    options.Authority = builder.Configuration["AuthServerUrl"];
    options.Audience = "ToNinetyOneWebApi";
    options.RequireHttpsMetadata = false;
    options.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            if (context.SecurityToken is JwtSecurityToken accessToken && context.Principal.Identity is ClaimsIdentity identity)
            {
                identity.AddClaim(new Claim("access_token", accessToken.RawData));
            }

            return Task.CompletedTask;
        }
    };
});

builder.Services.AddSwaggerGen(config =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    config.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(config =>
{
    config.RoutePrefix = string.Empty;
    config.DocumentTitle = "ToNinetyOne Web Api";
    config.SwaggerEndpoint("swagger/v1/swagger.json", "ToNinetyOne API");
});

app.UseCustomExceptionHandler();

app.UseRouting();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    try
    {
        var context = serviceProvider.GetService<ToNinetyOneDbContext>();
        var userContext = serviceProvider.GetService<ToNinetyOneUserDbContext>();
        
        DbInitializer.Initialize(context);
        UserDbInitializer.Initialize(userContext);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
}

app.Run();