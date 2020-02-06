using DDD.NetCore.CrossCutting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DDD.NetCore.CervejaManager.Extensions
{
    public static class DependencyInjectorSetup
    {
        public static void AddDependencyInjectorSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            DependencyInjector.Register(services);
        }
    }
}
