using Microsoft.EntityFrameworkCore;
using RentKeeper.Data.Interfaces;
using RentKeeper.Data.Repositories;
using RentKeeper.Services.Entities;
using RentKeeper.Services.Interfaces;
using AutoMapper;
using System;
using RentKeeper.Data.Context;
using RentKeeper.Objects.Dtos.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAluguelService, AluguelService>();
builder.Services.AddDbContext<RentKeeperDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 41)) // ou a versão do seu MySQL
    ));
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IGoleiroService, GoleiroService>();
builder.Services.AddAutoMapper(typeof(UsuarioProfile));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAutoMapper(typeof(Program)); // escaneia todas as Profiles
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IGoleiroService, GoleiroService>();


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

