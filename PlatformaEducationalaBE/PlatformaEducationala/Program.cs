using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PlatformaEducationala.Api.Services;
using PlatformaEducationala.Core.User.Queries.Get;
using PlatformaEducationala.Data;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Platforma educationala",
            Description = "Foloseste endpoint-ul de login sa obtii jwt-ul necesar autorizarii"
        });

        options.AddSecurityDefinition("oauth", new OpenApiSecurityScheme
        {
            Description = "Standard Auth header using Bearer scheme",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey

        });
        options.OperationFilter<SecurityRequirementsOperationFilter>();
    });

builder.Services.AddDB(builder.Configuration);

builder.Services.AddMediatR(typeof(GetQuery).Assembly);

builder.Services.AddSpaStaticFiles(Configuration =>
{
    Configuration.RootPath = " wwwroot/spa";
});

builder.Services.AddCors();

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .WriteTo.File("../logs/logging.txt"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters =
                         new TokenValidationParameters
                         {
                             ValidateAudience = false,
                             ValidateIssuer = false,
                             ValidateIssuerSigningKey = true,
                             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                         };

    o.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = tokenInvalid =>
        {
            return Task.CompletedTask;
        }
    };
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseSpaStaticFiles();

app.UseRouting();
app.UseHttpsRedirection();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(p => p.WithOrigins("http://localhost:3000")
   .AllowAnyHeader()
   .AllowAnyMethod());

app.MapControllers();

//will use the angular static files only when the environment is different from the developement one
if (!app.Environment.IsDevelopment())
{
    app.UseSpa(spa => spa.Options.SourcePath = "wwwroot/spa");
}
app.Run();
