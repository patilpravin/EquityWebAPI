using Equity.Positions.Web.API.Services;
using Equity.Positions.Web.API.Services.Interface;
using Equity.Positions.Web.Domain.Equity.Interface;
using Equity.Positions.Web.Infrastructure;
using Equity.Positions.Web.Infrastructure.Repository;
using Equity.Positions.Web.Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();

builder.Services.AddDbContext<AppDBContext>(x => x.UseInMemoryDatabase("EquityTrade"));
builder.Services.AddTransient(typeof(IEquityRepository<>), typeof(EquityRepository<>));
builder.Services.AddTransient<IEquityService, EquityService>();
builder.Services.AddTransient<IEquity, Equity.Positions.Web.Domain.Equity.Equity>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();
