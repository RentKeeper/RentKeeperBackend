using Microsoft.EntityFrameworkCore;
using RentKeeper.Data.Context;
using RentKeeper.Data.Interfaces;
using RentKeeper.Data.Repositories;
using RentKeeper.Objects.Mappings;
using RentKeeper.Services.Entities;
using RentKeeper.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;    
using System.Text;


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
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication("Bearer")
	.AddJwtBearer("Bearer", options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = builder.Configuration["Jwt:Issuer"],
			ValidAudience = builder.Configuration["Jwt:Audience"],
			IssuerSigningKey = new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
			)
		};
	});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:5173") // Porta do Vite
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
// Define o documento Swagger/JSON
c.SwaggerDoc("v1", new OpenApiInfo
{
	Title = "RentKeeper API",
	Version = "v1"
});

var securityScheme = new OpenApiSecurityScheme
{
	Name = "Authorization",
	Description = "Digite 'Bearer {token}' (sem aspas) no campo abaixo:",
	In = ParameterLocation.Header,
	Type = SecuritySchemeType.ApiKey,
	Scheme = JwtBearerDefaults.AuthenticationScheme, // "Bearer"
	BearerFormat = "JWT"
};
c.AddSecurityDefinition("Bearer", securityScheme);

	var securityReq = new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				}
			},
			new string[] {}
		}
	};
	c.AddSecurityRequirement(securityReq);
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	// Configura o endpoint do SwaggerUI para incluir o esquema de segurança
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "RentKeeper API V1");
		// Mantém a UI do Swagger aberta mesmo sem token, mas habilita o botão Authorize
		c.DisplayRequestDuration();
	});
}
app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
// aqui entrará UseAuthentication() e UseAuthorization() quando adicionarmos JWT

app.MapControllers();

app.Run();
