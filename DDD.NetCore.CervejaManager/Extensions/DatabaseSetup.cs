using DDD.NetCore.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DDD.NetCore.CervejaManager.Extensions
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            // Overkill abstrair configuration?
            string conn = configuration.GetConnectionString("DefaultConnection");

            // TODO: Abstrair contexto?
            services.AddDbContext<ProjectContext>(options => options.UseSqlServer(conn));
        }
    }
}
