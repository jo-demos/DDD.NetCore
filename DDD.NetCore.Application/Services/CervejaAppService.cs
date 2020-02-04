using AutoMapper;
using DDD.NetCore.Application.DTO;
using DDD.NetCore.Application.Interfaces;
using DDD.NetCore.Domain.Entities;
using DDD.NetCore.Domain.Interfaces;

namespace DDD.NetCore.Application.Services
{
    public class CervejaAppService : AppServiceBase<CervejaEntity, CervejaDTO>, ICervejaAppService
    {
        private readonly ICervejaRepository _cervejaRepository;

        public CervejaAppService(IMapper mapper, ICervejaRepository cervejaRepository)
            : base(mapper, cervejaRepository)
        {
            _cervejaRepository = cervejaRepository;
        }
    }
}
