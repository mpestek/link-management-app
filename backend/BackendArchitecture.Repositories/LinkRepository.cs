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
            var links = _dbContext.Links
                .Where(link => link.UserId == userId)
                .Include(link => link.Tags)
                .ToList();

            links.Reverse();

            return links;
        }

        public List<string> GetSuggestedTags(string uri)
        {
            var tags = _dbContext.Links
                .Where(link => link.Uri == uri)
                .Include(link => link.Tags)
                .SelectMany(link => link.Tags)
                .GroupBy(tag => tag.Name)
                .Select(tagGroup => new { Name = tagGroup.Key, Count = tagGroup.Count() })
                .OrderByDescending(tagGroup => tagGroup.Count)
                .Select(tagGroup => tagGroup.Name)
                .ToList();

            return tags;
        }

        public List<string> GetSuggestedTagsFromAnalysis(string uri)
        {
            var tags = _dbContext.Links
                .Where(link => link.Uri == uri)
                .Include(link => link.AnalysisTagResults)
                .SelectMany(link => link.AnalysisTagResults)
                .GroupBy(tag => tag.Name)
                .Select(tagGroup => new { Name = tagGroup.Key, Count = tagGroup.Sum(tagGroup => tagGroup.Ocurrences) })
                .OrderByDescending(tagGroup => tagGroup.Count)
                .Select(tagGroup => tagGroup.Name)
                .ToList();

            return tags;
        }
    }
}
