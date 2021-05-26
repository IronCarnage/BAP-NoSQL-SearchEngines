using Azure.Search.Documents;
using Azure.Search.Documents.Models;
using BAP_NoSQL_SearchEngines.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAP_NoSQL_SearchEngines.Repositories
{
    class ArticleAzureSearch
    {
        private readonly AzureSearchRepository searchRepository;
        private readonly ArticleRepository articleRepository;


        public ArticleAzureSearch(AzureSearchRepository searchRepository, ArticleRepository articleRepository)
        {
            this.searchRepository = searchRepository;
            this.articleRepository = articleRepository;
        }

        public async Task CreateOrDropAndCreateIndex()
        {
            await searchRepository.CreateIndexIfNotExists<ArticleDTO>();
        }

        public async Task RebuildIndex()
        {
            await CreateOrDropAndCreateIndex();

            await IndexArticles();
        }

        private async Task IndexArticles()
        {
            double currentTotal = 0;
            List<ArticleDTO> articles = articleRepository.GetAllArticles();
            double totalCount = articles.Count();
            
            SearchClient client = searchRepository.GetIndexClient();

            while (currentTotal < totalCount)
            {
                IndexDocumentsBatch<ArticleDTO> batch = IndexDocumentsBatch.MergeOrUpload<ArticleDTO>(articles.Skip((int)currentTotal).Take(1000));

                IndexDocumentsResult result = await client.IndexDocumentsAsync(batch);

                currentTotal += 1000;
            }
        }

        public async Task<int> Search(int take, int page, string searchTerm)
        {
            var indexClient = searchRepository.GetIndexClient();

            var options = new SearchOptions();

            options.Size = take;
            options.Skip = take * (page - 1);

            var response = await indexClient.SearchAsync<ArticleDTO>(searchTerm, options);
            var result = response.Value.GetResults().Count();


            return (int)result;
        }
    }
}
