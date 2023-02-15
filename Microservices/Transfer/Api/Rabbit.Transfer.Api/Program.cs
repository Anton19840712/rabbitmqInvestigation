using MediatR;
using Microsoft.EntityFrameworkCore;
using Rabbit.Domain.Core.Bus;
using Rabbit.Infrastructure.Ioc;
using Rabbit.Transfer.Data.Context;
using Rabbit.Transfer.Domain.EventHandlers;
using Rabbit.Transfer.Domain.Events;

var builder = WebApplication.CreateBuilder(args);

// AddAsync services to the container.
var services = builder.Services;
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var configurationBuilder = new ConfigurationBuilder()
	.SetBasePath(Directory.GetCurrentDirectory())
	.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var configuration = configurationBuilder.Build();
var connectionString = configuration.GetConnectionString("TransferDbConnection");

services.AddDbContext<TransferDbContext>(options =>
{
	options.UseSqlServer(connectionString);
});

services.AddMediatR(typeof(DependencyContainer));
DependencyContainer.RegisterServices(services);
services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Transfer microservice", Version = "v1" });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transfer microservice V1");
	});
}

ConfigureEventBus(app);

void ConfigureEventBus(IApplicationBuilder appBuilder)
{
	var eventBus = appBuilder.ApplicationServices.GetRequiredService<IEventBus>();
	eventBus.Subscribe<TransferCreatedEvent, TransferEventHandler>();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
