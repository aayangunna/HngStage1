using HngStage1.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace HngStage1
{
    public class Program
    {
        private readonly IConfiguration Configuration;
        public Program(IConfiguration configuration)
        {
            Configuration = configuration; 
        }
        //public IConfiguration Configuration { get; }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.



            IConfiguration configuration;
            configuration = builder.Configuration;
            var conn = configuration.GetValue<String>("ConnectionStrings:HngDatabase");
            builder.Services.AddDbContext<HngDbContext>(options => options.UseSqlServer(conn));





            builder.Services.AddCors(options => options.AddPolicy("AllowEverything", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped< IHngService, HngService>();

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