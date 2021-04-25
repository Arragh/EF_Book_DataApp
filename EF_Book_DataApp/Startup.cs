using EF_Book_DataApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF_Book_DataApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddDbContext<EFDatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PlayStationProducts")));
            services.AddDbContext<EFCustomerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PlayStationCustomers")));
            services.AddTransient<IDataRepository, EFDataRepository>();
            services.AddTransient<ICustomerRepository, EFCustomerRepository>();
            services.AddTransient<ISupplierRepository, EFSupplierRepository>();
            services.AddTransient<IGenericRepository<ContactDetails>, GenericRepository<ContactDetails>>();
            services.AddTransient<IGenericRepository<ContactLocation>, GenericRepository<ContactLocation>>();
            services.AddTransient<MigrationsManager>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
