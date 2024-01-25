
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrivateCollection.Data;
using PrivateCollection.Interfaces;
using PrivateCollection.Models;
using PrivateCollection.Repository;
using System.Reflection;

namespace PrivateCollection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IBoardGameRepository, BoardGameRepository>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
            });

            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 10;
            })
                .AddEntityFrameworkStores<PrivateCollectionContext>();

            builder.Services.AddDbContext<PrivateCollectionContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("PrivateCollectionDB")));

            var app = builder.Build();

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
