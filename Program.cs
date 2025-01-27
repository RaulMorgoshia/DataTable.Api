
using DataForm.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace DataForm.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddDbContext<ApplicationDbContext>(options =>
    
            options.UseMySql(
        
                builder.Configuration.GetConnectionString("DefaultConnection"),
        
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    
        
                ));




            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    // This allows all origins, which effectively disables CORS restrictions
                    policy.AllowAnyOrigin()  // Disable CORS by allowing all origins
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            app.UseCors();

            app.Run();
        }
    }
}
