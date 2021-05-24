using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using BAP_NoSQL_SearchEngines.IRepositories;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace BAP_NoSQL_SearchEngines.Repositories
{
    class AzureSearchRepository : ISearchRepository
    {
        private static readonly string searchServiceEndPoint = ConfigurationManager.AppSettings["AzureSearchService"];
        private static readonly string apiKey = ConfigurationManager.AppSettings["AzureApiKey"];
        private static readonly string indexName = ConfigurationManager.AppSettings["IndexName"];

        private static readonly SearchIndexClient SearchIndexClient = new SearchIndexClient(new Uri(searchServiceEndPoint), new AzureKeyCredential(apiKey));
        private static readonly SearchClient IndexClient = new SearchClient(new Uri(searchServiceEndPoint), indexName, new AzureKeyCredential(apiKey));


        public async Task CreateIndex<T>() where T : class
        {
            FieldBuilder fieldBuilder = new FieldBuilder();
            var searchFields = fieldBuilder.Build(typeof(T));

            var definition = new SearchIndex(indexName, searchFields);

            await SearchIndexClient.CreateOrUpdateIndexAsync(definition);
        }

        public async Task CreateIndexIfNotExists<T>() where T : class
        {
            try
            {
                if (await SearchIndexClient.GetIndexAsync(indexName) != null)
                {
                    await DropAndCreateIndex<T>();
                }
                else
                {
                    await CreateIndex<T>();
                }
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                await CreateIndex<T>();
            }
        }

        public async Task DeleteIndex<T>() where T : class
        {
            try
            {
                if (await SearchIndexClient.GetIndexAsync(indexName) != null)
                {
                    await SearchIndexClient.DeleteIndexAsync(indexName);
                }
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                //do nothing
                //await CreateIndex<T>();
            }
        }

        public async Task DropAndCreateIndex<T>() where T : class
        {
            await DeleteIndex<T>();
            await CreateIndex<T>();
        }


        public SearchClient GetIndexClient()
        {
            return IndexClient;
        }

    }
}
