using MonolithToMicroserviceApi.Search.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonolithToMicroserviceApi.Search.Services
{
    public class SearchService : ISearchService
    {
        public async Task<IEnumerable<SearchRecord>> PerformSearchAsync(string searchTerm)
        {
            return new[] { new SearchRecord { Info = searchTerm } };
        }
    }
}
