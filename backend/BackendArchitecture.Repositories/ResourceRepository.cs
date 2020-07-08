using BackendArchitecture.Entities;
using BackendArchitecture.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackendArchitecture.Repositories
{
    public class ResourceRepository : BaseRepository<Resource>, IResourceRepository
    {
        public ResourceRepository(MyDatabaseDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
