using BAP_NoSQL_SearchEngines.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrNet;
using BAP_NoSQL_SearchEngines.DTO;
using SolrNet.Impl;
using CommonServiceLocator;
using System.Configuration;

namespace BAP_NoSQL_SearchEngines.Repositories
{
    class SolrSearchRepository : ISearchRepository
    {
        private static readonly string connectionString = ConfigurationManager.AppSettings["SolrLocalConnectionString"];
        private static readonly string IndexName = ConfigurationManager.AppSettings["IndexName"];
        ISolrOperations<ArticleDTO> client;
        
        public SolrSearchRepository()
        {
            ISolrConnection connection = new SolrConnection(connectionString + IndexName);
            Startup.Init<ArticleDTO>(connection);
            this.client = ServiceLocator.Current.GetInstance<ISolrOperations<ArticleDTO>>();
        }

        public async Task CreateIndex<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public async Task CreateIndexIfNotExists<T>() where T : class
        {
            await DeleteIndex<T>();
        }

        public async Task DeleteIndex<T>() where T : class
        {
            await client.DeleteAsync(SolrQuery.All);
        }

        public async Task DropAndCreateIndex<T>() where T : class
        {
            await DeleteIndex<T>();
        }

        public ISolrOperations<ArticleDTO> GetIndexClient()
        {
            return this.client;
        }
    }
}
