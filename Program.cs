using Microsoft.EntityFrameworkCore;
using WebTuor.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebTuorDbContext>(options => {
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

var app = builder.Build();

app.Run();
