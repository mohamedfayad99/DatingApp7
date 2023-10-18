using API_Project.Data;
using API_Project.Services;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Extentions
{
    public static class ApplicationServicesExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config) 
        {
            services.AddDbContext<ApplicationDB>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ITokenService, TokenService>();
            services.AddCors();
            return services;
        }
        
    }
}
