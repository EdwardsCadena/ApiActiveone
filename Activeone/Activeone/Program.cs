using Microsoft.EntityFrameworkCore;
using Activeone.Core.Interfaces;
using Activeone.Infrastructure.Data;
using Activeone.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<activeone1Context>(options =>
{
   options.UseSqlServer(builder.Configuration.GetConnectionString("activeone"));
});

builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<ICdRepository, CdRepository>();
builder.Services.AddTransient<IAlquilerRepository, AlquilerRepository>();

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

app.Run();
