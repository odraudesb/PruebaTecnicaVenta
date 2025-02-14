
using API.Services;
using Core.Interfaces;
using Infraestructura;
using Infraestructura.Repositorio;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurar Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            builder.Host.UseSerilog();

            // Configurar DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();
            builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IVendedorRepository, VendedorRepository>();

            builder.Services.AddScoped<FacturaService>();
            builder.Services.AddScoped<ProductoService>();
            builder.Services.AddScoped<ClienteService>();
            builder.Services.AddScoped<VendedorService>();

            // Configurar CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            // Configurar Swagger y API Controllers
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configurar Middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Aplicar CORS antes de Authorization
            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}
