using CarRentalSystemAPI.Data;
using CarRentalSystemAPI.Repositories;
using CarRentalSystemAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

var jwtVal = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtVal["Key"]);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// My Services....................
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<RentalRepository>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<ICarRentalService, CarRentalService>();


//Email Service Configuration



// Configuration of JWT Servic............................
// First Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(op =>
{
    op.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtVal["Issuer"],
        ValidAudience = jwtVal["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key),

    };
});

// Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", j => j.RequireRole("Admin"));
    options.AddPolicy("All", j => j.RequireRole(["Admin", "User"]));
});

// Db Context
builder.Services.AddDbContext<CarDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Custom Middleware for JWT Service
//app.UseAuthMiddleware();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
