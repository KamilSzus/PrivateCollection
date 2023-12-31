
using Microsoft.EntityFrameworkCore;
using PrivateCollection.Data;
using PrivateCollection.Interfaces;
using PrivateCollection.Repository;
using System.Reflection;

namespace PrivateCollection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddDbContext<PrivateCollectionContext>(options => options.UseSqlite());
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
            });

            builder.Services.AddDbContext<PrivateCollectionContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("PrivateCollectionDB")));

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
