using System.Collections.Generic;

namespace MonolithToMicroserviceApi.Search.WebApi.Models
{
    public class SearchResponse
    {
        public SearchRequest SearchRequest { get; set; }
        public IEnumerable<SearchResult> Results { get; set; }
    }
}
