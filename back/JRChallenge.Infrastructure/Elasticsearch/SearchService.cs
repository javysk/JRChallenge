using Nest;

namespace JRChallenge.Infrastructure.Elasticsearch
{
    public class SearchService
    {
        private readonly ElasticClient _client;

        public SearchService(IElasticsearchService elasticsearchService)
        {
            _client = elasticsearchService.GetClient();
        }

        public ISearchResponse<T> Search<T>(Func<SearchDescriptor<T>, ISearchRequest> searchDescriptor)
            where T : class
        {
            return _client.Search(searchDescriptor);
        }

        public ISearchResponse<T> Search<T>(string searchText) where T : class
        {
            var response = _client.Search<T>(s => s
                .Query(q => q
                    .Match(m => m
                        .Query(searchText)
                    )
                )
            );

            return response;
        }

    }
}
