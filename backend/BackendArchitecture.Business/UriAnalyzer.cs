using BackendArchitecture.Business.Interfaces;
using BackendArchitecture.Entities;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BackendArchitecture.Business
{
    public class UriAnalyzer : IUriAnalyzer
    {
        public async Task<List<AnalysisTagResult>> AnalyzeKeywordOcurrences(string uri)
        {
            var htmlWeb = new HtmlWeb();
            var document = await htmlWeb.LoadFromWebAsync(uri);

            var contentNodes = document.DocumentNode
                .SelectNodes("//text()")
                .Where(node =>
                    node.ParentNode.Name != "script" &&
                    node.ParentNode.Name != "meta" &&
                    node.ParentNode.Name != "head")
                .Select(node => node.InnerText.Trim(' ', '\n', '\r', '\t', ',', '.', '|', ':'))
                .Where(text => !String.IsNullOrEmpty(text))
                .GroupBy(text => text)
                .Select(text => new AnalysisTagResult { Name = text.Key, Ocurrences = text.Count() })
                .OrderByDescending(tagResult => tagResult.Ocurrences)
                .Where(tagResult => tagResult.Ocurrences > 1)
                .ToList();

            return contentNodes;
        }
    }
}
