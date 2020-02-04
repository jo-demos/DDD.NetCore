using DDD.NetCore.Application.Interfaces;
using DDD.NetCore.Application.Services;
using DDD.NetCore.Data.Repositories;
using DDD.NetCore.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.NetCore.CrossCutting
{
    public static class DependencyInjector
    {
        public static void Register(IServiceCollection collect)
        {
            collect.AddScoped(typeof(IAppServiceBase<,>), typeof(AppServiceBase<,>));

            collect.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        }
    }
}