using AutoMapper;
using DDD.NetCore.Application.DTO;
using DDD.NetCore.Application.Interfaces;
using DDD.NetCore.Domain.Entities;
using DDD.NetCore.Domain.Interfaces;

namespace DDD.NetCore.Application.Services
{
    public class RevendedorAppService : AppServiceBase<RevendedorEntity, RevendedorDTO>, IRevendedorAppService
    {
        private readonly IMapper _mapper;
        private readonly IRevendedorRepository _revendedorRepository;

        public RevendedorAppService(IMapper mapper, IRevendedorRepository revendedorRepository)
            : base(mapper, revendedorRepository)
        {
            _mapper = mapper;
            _revendedorRepository = revendedorRepository;
        }
    }
}
