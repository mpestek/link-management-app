using BackendArchitecture.Entities;
using BackendArchitecture.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackendArchitecture.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntityBase, new()
    {
        private readonly DbContext _dbContext;
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TEntity> Get()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public TEntity Get(Guid id)
        {
            return _dbContext.Set<TEntity>().Where(res => res.Id == id).FirstOrDefault();
        }

        public TEntity Create(TEntity resource)
        {
            resource.Id = Guid.Empty;

            _dbContext.Set<TEntity>().Add(resource);
            _dbContext.SaveChanges();

            return resource;
        }

        public void Update(TEntity resource)
        {
            _dbContext.Entry(resource).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _dbContext.Set<TEntity>().Remove(new TEntity { Id = id });
            _dbContext.SaveChanges();
        }
    }
}
