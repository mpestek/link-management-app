using BackendArchitecture.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendArchitecture.Repositories.Interfaces
{
    public interface ILinkRepository : IBaseRepository<Link>
    {
        List<Link> GetLinksForUser(Guid userId);

        List<string> GetSuggestedTags(string uri);
    }
}
