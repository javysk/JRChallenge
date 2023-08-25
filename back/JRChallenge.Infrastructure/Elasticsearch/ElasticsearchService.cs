using Microsoft.Extensions.Options;
using Nest;
using System;

namespace JRChallenge.Infrastructure.Elasticsearch
{
    public class ElasticsearchService : IElasticsearchService
    {
        private readonly ElasticClient _client;

        public ElasticsearchService(IOptions<ElasticsearchSettings> settings)
        {
            var connectionSettings = new ConnectionSettings(new Uri(settings.Value.Url))
                .DefaultIndex(settings.Value.DefaultIndex)
                 .BasicAuthentication("elastic", settings.Value.Password);

            _client = new ElasticClient(connectionSettings);
        }

        public ElasticClient GetClient() => _client;

        public void IndexDocument<T>(T document, string id) where T : class
        {
            try
            {
                var indexResponse = _client.Index(document, idx => idx
                    .Index(_client.ConnectionSettings.DefaultIndex)
                    .Id(id)
                );

                if (!indexResponse.IsValid)
                {
                    throw new Exception($"Failed to index document: {indexResponse.DebugInformation}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
