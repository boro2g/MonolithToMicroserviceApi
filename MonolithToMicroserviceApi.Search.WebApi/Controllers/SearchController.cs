using Microsoft.AspNetCore.Mvc;
using MonolithToMicroserviceApi.Search.Services;
using MonolithToMicroserviceApi.Search.Services.Models;
using MonolithToMicroserviceApi.Search.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithToMicroserviceApi.Search.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        //example url - /search?searchTerm=cat
        public async Task<SearchResponse> Get(string searchTerm)
        {
            return Map(await _searchService.PerformSearchAsync(searchTerm), new SearchRequest { SearchTerm = searchTerm });
        }

        private SearchResponse Map(IEnumerable<SearchRecord> records, SearchRequest request)
        {
            var searchResponse = new SearchResponse
            {
                SearchRequest = request,
                Results = records.Select(a => new SearchResult { Result = a.Info })
            };

            return searchResponse;
        }
    }
}
