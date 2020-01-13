using CostRegisterMobile.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CostRegisterMobile.Repositories
{
    /// <summary>
    /// Generic base class for Repository classes.
    /// </summary>
    public class CostPlansRepositoryBase<TEntity> : IDisposable, ICostPlansRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly CostPlansContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public CostPlansRepositoryBase()
        {
            _context = new CostPlansContext();
            _dbSet = _context.Set<TEntity>();
        }

        public CostPlansRepositoryBase(CostPlansContext costPlansContext)
        {
            _context = costPlansContext;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Update(int id)
        {

        }

        public virtual void Delete(int id)
        {
            Delete(_dbSet.Find(id));
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void DeleteAllUserDatas()
        {
            _dbSet.RemoveRange(_dbSet);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CostPlansRepositoryBase()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);          
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
