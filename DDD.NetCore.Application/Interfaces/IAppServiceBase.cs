using System;
using System.Collections.Generic;

namespace DDD.NetCore.Application.Interfaces
{
    public interface IAppServiceBase<TEntity, TEntityDTO> : IDisposable
        where TEntity : class
        where TEntityDTO : class
    {
        void Add(TEntityDTO objDTO);
        TEntityDTO GetById(int id);
        IEnumerable<TEntityDTO> GetAll();
        void Update(TEntityDTO objDTO);
        void Remove(int id);
        void Remove(TEntityDTO objDTO);
    }
}
