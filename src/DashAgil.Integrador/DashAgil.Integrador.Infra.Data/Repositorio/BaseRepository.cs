using Dapper.Contrib.Extensions;
using DashAgil.Integrador.Infra.Data.Context;
using DashAgil.Integrador.Repositorio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Infra.Data.Repositorio
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public long Add(TEntity obj)
        {
            return _context.Connection.Insert<TEntity>(obj);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Connection.GetAllAsync<TEntity>();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _context.Connection.GetAsync<TEntity>(id);
        }

        public bool Remove(TEntity obj)
        {
            return _context.Connection.Delete<TEntity>(obj);
        }

        public bool Update(TEntity obj)
        {
            return _context.Connection.Update<TEntity>(obj);
        }
    }
}
