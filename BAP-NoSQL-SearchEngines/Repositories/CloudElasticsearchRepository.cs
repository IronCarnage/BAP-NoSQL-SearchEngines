using BAP_NoSQL_SearchEngines.IRepositories;
using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAP_NoSQL_SearchEngines.Repositories
{
    public class CloudElasticsearchRepository : ISearchRepository
    {
        private static readonly string ElasticCloudId = ConfigurationManager.AppSettings["ElasticCloudId"];
        private static readonly string ElasticApiId = ConfigurationManager.AppSettings["ElasticCloudApiId"];
        private static readonly string ElasticApiKey = ConfigurationManager.AppSettings["ElasticCloudApiKey"];
        private static readonly string IndexName = ConfigurationManager.AppSettings["IndexName"];
        private static readonly IElasticClient elasticClient = new ElasticClient(new ConnectionSettings(new CloudConnectionPool(ElasticCloudId, new ApiKeyAuthenticationCredentials(ElasticApiId, ElasticApiKey))).DefaultIndex(IndexName));

        public async Task CreateIndexIfNotExists<T>() where T : class
        {
            if (!elasticClient.Indices.Exists(elasticClient.ConnectionSettings.DefaultIndex).IsValid)
            {
                await CreateIndex<T>();
            }
            else
            {
                await DropAndCreateIndex<T>();
            }
        }

        public async Task DropAndCreateIndex<T>() where T : class
        {
            await DeleteIndex<T>();
            await CreateIndex<T>();
        }

        public async Task CreateIndex<T>() where T : class
        {
            await elasticClient.Indices.CreateAsync(elasticClient.ConnectionSettings.DefaultIndex, i => i
                .Map<T>(m => m.AutoMap<T>()));
        }

        public async Task DeleteIndex<T>() where T : class
        {
            await elasticClient.Indices.DeleteAsync(elasticClient.ConnectionSettings.DefaultIndex);
        }

        public IElasticClient GetIndexClient()
        {
            return elasticClient;
        }

    }
}
