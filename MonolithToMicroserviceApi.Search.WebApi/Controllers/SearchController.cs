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
        public async Task<SearchResponse> Get(SearchRequest request)
        {
            return Map(await _searchService.PerformSearchAsync(request.SearchTerm), request);
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
