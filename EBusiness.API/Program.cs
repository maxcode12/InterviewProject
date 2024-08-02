using EBusiness.API.Context;
using EBusiness.API.Interfaces;
using EBusiness.API.Repositories;
using EBusiness.API.Server.Models;
using EBusiness.API.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Register Configuration
ConfigurationManager configuration = builder.Configuration;
 
var connectionString = configuration.GetConnectionString("DefaultConnection");
// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Identity Settings
builder.Services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
builder.Services.AddIdentity<User, IdentityRole>(
            op => op.SignIn.RequireConfirmedAccount = true)
                        .AddEntityFrameworkStores<EBuisinessContextDB2024>()
                        .AddDefaultTokenProviders();

// Add DbContext
builder.Services.AddDbContext<EBuisinessContextDB2024>(opt =>
{
    opt.UseSqlServer(connectionString);
});

// Add Repositories
builder.Services.AddScoped<IAuthenticateUser, AuthenticateUser>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRolePermission, RolePermission>();

// Authentication and Authorization
builder.Services.AddAuthentication(
            options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };
            });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
