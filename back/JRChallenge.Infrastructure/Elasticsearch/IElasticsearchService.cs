using Nest;

namespace JRChallenge.Infrastructure.Elasticsearch
{
    public interface  IElasticsearchService
    {
        public ElasticClient GetClient();

        public void IndexDocument<T>(T document, string id) where T : class;
    }
}
