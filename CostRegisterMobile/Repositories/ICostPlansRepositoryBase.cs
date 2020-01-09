using System;
using System.Collections.Generic;

namespace CostRegisterMobile.Repositories
{
    interface ICostPlansRepositoryBase<TEntity> : IDisposable
    {
        void Create(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Update(int id);
        void Delete(int id);
        void Delete(TEntity entity);
    }
}
