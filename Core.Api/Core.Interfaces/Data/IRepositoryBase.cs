using Core.Interfaces.Data;
using System;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IRepositoryBase <TEntity> : IDisposable where TEntity : class
    {
        IDatabase database { get; }

        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        TEntity GetById(int id);
        List<TEntity> GetAll();        
    }
}
