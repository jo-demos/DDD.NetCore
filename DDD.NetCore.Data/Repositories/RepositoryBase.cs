using DDD.NetCore.Data.Contexts;
using DDD.NetCore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD.NetCore.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ProjectContext _context;

        public RepositoryBase(ProjectContext context)
        {
            _context = context;
        }

        public void Add(TEntity obj)
        {
            _context.InitTransaction();
            _context.Set<TEntity>().Add(obj);
            _context.SendChanges();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            _context.InitTransaction();
            _context.Entry(obj).State = EntityState.Modified;
            _context.SendChanges();
        }

        public void Remove(TEntity obj)
        {
            _context.InitTransaction();
            _context.Set<TEntity>().Remove(obj);
            _context.SendChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
