using DDD.NetCore.Application.DTO;
using DDD.NetCore.Domain.Entities;

namespace DDD.NetCore.Application.Interfaces
{
    public interface IRevendedorAppService : IAppServiceBase<RevendedorEntity, RevendedorDTO>
    {
    }
}
