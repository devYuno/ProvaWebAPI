using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebTuor.Endpoints;
using WebTuor.Models;
using WebTuor.Services.JWT;
using WebTuor.Services.Users;
using WebTuor.UseCases.CreatePasseio;
using WebTuor.UseCases.EditPasseio;
using WebTuor.UseCases.Login;
using WebTuor.UseCases.SeePasseio;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebTuorDbContext>(options => {
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = "WebTuor",
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = key,
        };
    });

builder.Services.AddSingleton<IJWTService, JWTService>();
builder.Services.AddTransient<IUsersService, EFUserService>();
builder.Services.AddTransient<CreatePasseioUseCase>();
builder.Services.AddTransient<LoginUseCase>();
builder.Services.AddTransient<EditPasseioUseCase>();
builder.Services.AddTransient<SeePasseioUseCase>();


builder.Services.AddAuthentication();
builder.Services.AddAuthorization();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.ConfigureAuthEndpoints();
app.ConfigureUserEndpoints();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
