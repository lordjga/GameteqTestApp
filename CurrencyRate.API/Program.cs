using Autofac;
using Autofac.Extensions.DependencyInjection;
using GameteqTestApp.BL.AppServices;
using GameteqTestApp.DA.EFCore.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(ConfigureContainer);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy("Cors", builder =>
{
	builder
		.AllowAnyOrigin()
		.AllowAnyMethod()
		.AllowAnyHeader();
}));

builder.Services.AddDbContext<CurrencyAppContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("Cors");

MigrateDatabase(app);

app.Run();

void ConfigureContainer(ContainerBuilder builder)
{
	builder.RegisterModule<AppServicesRegistrationModule>();
	builder.RegisterModule<EfCoreRegistrationModule>();
	builder.RegisterModule<DaServicesRegistrationModule>();
}

void MigrateDatabase(IApplicationBuilder app)
{
	using (var serviceScope = app.ApplicationServices
		.GetRequiredService<IServiceScopeFactory>()
		.CreateScope())
	{
		using (var context = serviceScope.ServiceProvider.GetService<CurrencyAppContext>())
		{
			context.Database.Migrate();
		}
	}
}