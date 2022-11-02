using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;

namespace NZWalksAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            Action<DbContextOptionsBuilder> AddDbContextLambda = 
                options => 
                { 
                    options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalks")); 
                };
            builder.Services.AddDbContext<NZWalksDBContext>(AddDbContextLambda);

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
        }
    }
}