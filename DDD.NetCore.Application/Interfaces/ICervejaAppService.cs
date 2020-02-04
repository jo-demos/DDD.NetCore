using DDD.NetCore.Application.DTO;
using DDD.NetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.NetCore.Application.Interfaces
{
    public interface ICervejaAppService : IAppServiceBase<CervejaEntity, CervejaDTO>
    {
    }
}
