using Microsoft.EntityFrameworkCore;
using RentKeeper.Data.Context;
using RentKeeper.Data.Interfaces;
using RentKeeper.Data.Repositories;
using RentKeeper.Objects.Mappings;
using RentKeeper.Services.Entities;
using RentKeeper.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar PostgreSQL
builder.Services.AddDbContext<RentKeeperDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddAutoMapper(typeof(UsuarioProfile));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAnuncioRepository, AnuncioRepository>();
builder.Services.AddScoped<IAnuncioService, AnuncioService>();
builder.Services.AddAutoMapper(typeof(UsuarioProfile), typeof(AnuncioProfile));
builder.Services.AddScoped<IAluguelRepository, AluguelRepository>();
builder.Services.AddScoped<IAluguelService, AluguelService>();
builder.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddScoped<IPagamentoService, PagamentoService>();
builder.Services.AddScoped<ITimeRepository, TimeRepository>();
builder.Services.AddScoped<ITimeService, TimeService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// aqui entrará UseAuthentication() e UseAuthorization() quando adicionarmos JWT

app.MapControllers();

app.Run();
