using BackendArchitecture.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackendArchitecture.Business.Interfaces
{
    public interface IUriAnalyzer
    {
        Task<List<AnalysisTagResult>> AnalyzeKeywordOcurrences(string uri);
    }
}
