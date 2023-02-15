using Microsoft.EntityFrameworkCore;
using Rabbit.Banking.Data.Context;
using Rabbit.Infrastructure.Ioc;
using Microsoft.Extensions.Configuration;
using MediatR;
using Rabbit.Banking.Application.Interfaces;
using Rabbit.Banking.Application.Services;
using Rabbit.Banking.Data.Repository;
using Rabbit.Banking.Domain.Interfaces;
using Rabbit.Domain.Core.Bus;
using Rabbit.Infrastructure.Bus;

var builder = WebApplication.CreateBuilder(args);

// AddAsync services to the container.
var services = builder.Services;
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var configurationBuilder = new ConfigurationBuilder()
	.SetBasePath(Directory.GetCurrentDirectory())
	.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var configuration = configurationBuilder.Build();
var connectionString = configuration.GetConnectionString("BankingDbConnection");

services.AddDbContext<BankingDbContext>(options =>
{
	options.UseSqlServer(connectionString);
});

services.AddMediatR(typeof(DependencyContainer));
DependencyContainer.RegisterServices(services);

services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Banking microservice", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking microservice V1");
	});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
