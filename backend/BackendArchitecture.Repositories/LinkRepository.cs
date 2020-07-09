using BackendArchitecture.Entities;
using BackendArchitecture.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackendArchitecture.Repositories
{
    public class LinkRepository : BaseRepository<Link>, ILinkRepository
    {
        public LinkRepository(MyDatabaseDbContext dbContext)
            : base(dbContext)
        {
        }

        public List<Link> GetLinksForUser(Guid userId)
        {
            return _dbContext.Links
                .Where(link => link.UserId == userId)
                .Include(link => link.Tags)
                .ToList();
        }
    }
}
