using System;
using System.Collections.Generic;
using System.Text;

namespace BackendArchitecture.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        List<TEntity> Get();
        TEntity Get(Guid id);
        TEntity Create(TEntity resource);
        void Update(TEntity resource);
        void Delete(Guid id);
    }
}
