using ASP.NET.Data;
using ASP.NET.Repositorios;
using ASP.NET.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;


namespace ASP.NET
{
    public class Program
    {
            
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the  

            // Conexão ao banco de Dados MySql
            string MySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<SistemaDB> (options => options.UseMySql
            (
                MySqlConnection, ServerVersion.Parse("8.0.32-mysql"))
            );

            //################################

            //Relação de dependência

            builder.Services.AddScoped<TeamInterface, RTeam>();
            builder.Services.AddScoped<EmployeeInterface, REmployee>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //################################

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
        }
    }
}