using AutoMapper;
using DDD.NetCore.Application.DTO;
using DDD.NetCore.Domain.Entities;

namespace DDD.NetCore.Application
{
    public class EntityMapping : Profile
    {
        public EntityMapping()
        {
            CreateMap<EntityBase, DTOBase>()
                .ForMember(m => m.Id, d => d.MapFrom(s => s.PkId))
                .ReverseMap();

            CreateMap<CervejaEntity, CervejaDTO>()
                .ForMember(m => m.Nome, d => d.MapFrom(s => s.DsNome))
                .ForMember(m => m.TeorAlcoolico, d => d.MapFrom(s => s.VlTeorAlcoolico))
                .ForMember(m => m.Preco, d => d.MapFrom(s => s.VlPreco))
                .ReverseMap();

            CreateMap<RevendedorEntity, RevendedorDTO>()
                .ForMember(m => m.Nome, d => d.MapFrom(s => s.DsNome))
                .ReverseMap();
        }
    }
}
