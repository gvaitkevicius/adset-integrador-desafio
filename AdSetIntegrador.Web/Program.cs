using Microsoft.EntityFrameworkCore;
using AdSetIntegrador.Data.Data;
using AdSetIntegrador.Data.Repositories;
using AdSetIntegrador.Web.Services;
using SoapCore;


namespace AdSetIntegrador.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configure the database context
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Register the repository
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Register SOAP services
            builder.Services.AddScoped<ICarService, CarService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Configure the SOAP endpoint
         //   app.UseSoapEndpoint<ICarService>("/Service.svc", new SoapEncoderOptions(), SoapSerializer.DataContractSerializer, true);



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Car}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
