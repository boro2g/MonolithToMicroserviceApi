using MonolithToMicroserviceApi.Search.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonolithToMicroserviceApi.Search.Services
{
    public interface ISearchService
    {
        Task<IEnumerable<SearchRecord>> PerformSearchAsync(string searchTerm);
    }
}