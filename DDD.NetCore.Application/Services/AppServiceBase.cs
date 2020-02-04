using AutoMapper;
using DDD.NetCore.Application.Interfaces;
using DDD.NetCore.Domain.Interfaces;
using System.Collections.Generic;

namespace DDD.NetCore.Application.Services
{
    public class AppServiceBase<TEntity, TEntityDTO> : IAppServiceBase<TEntity, TEntityDTO>
        where TEntity : class
        where TEntityDTO : class
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public AppServiceBase(IMapper mapper, IRepositoryBase<TEntity> repositoryBase)
        {
            this._mapper = mapper;
            this._repositoryBase = repositoryBase;
        }

        public void Add(TEntityDTO objDTO)
        {
            TEntity obj = _mapper.Map<TEntity>(objDTO);

            _repositoryBase.Add(obj);
        }

        public TEntityDTO GetById(int id)
        {
            TEntity obj = _repositoryBase.GetById(id);

            TEntityDTO objDTO = _mapper.Map<TEntityDTO>(obj);

            return objDTO;
        }

        public IEnumerable<TEntityDTO> GetAll()
        {
            IEnumerable<TEntity> listObj = _repositoryBase.GetAll();

            IEnumerable<TEntityDTO> listObjDTO = _mapper.Map<IEnumerable<TEntityDTO>>(listObj);

            return listObjDTO;
        }

        public void Update(TEntityDTO objDTO)
        {
            TEntity obj = _mapper.Map<TEntity>(objDTO);

            _repositoryBase.Update(obj);
        }

        public void Remove(int id)
        {
            TEntityDTO objDTO = GetById(id);

            Remove(objDTO);
        }

        public void Remove(TEntityDTO objDTO)
        {
            TEntity obj = _mapper.Map<TEntity>(objDTO);

            _repositoryBase.Remove(obj);
        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
        }
    }
}
