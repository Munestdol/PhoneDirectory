using Npgsql;
using PhoneDirectory.Repositories;
using PhoneDirectory.Services;

namespace PhoneDirectory
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Регистрация NpgsqlConnection
            services.AddTransient<NpgsqlConnection>(sp =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                return new NpgsqlConnection(connectionString);
            });

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
