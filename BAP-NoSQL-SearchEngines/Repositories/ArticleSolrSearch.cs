using BAP_NoSQL_SearchEngines.DTO;
using SolrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrNet;
using SolrNet.Commands.Parameters;

namespace BAP_NoSQL_SearchEngines.Repositories
{
    class ArticleSolrSearch
    {
        private readonly SolrSearchRepository searchRepository;
        private readonly ArticleRepository articleRepository;

        public ArticleSolrSearch(SolrSearchRepository searchRepository, ArticleRepository articleRepository)
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

            ISolrOperations<ArticleDTO> client = searchRepository.GetIndexClient();
            
            while (currentTotal < totalCount)
            {
                IEnumerable<ArticleDTO> batch = articles.Skip((int)currentTotal).Take(1000);
                await client.AddRangeAsync(batch);

                currentTotal += 1000;
            }
            await client.CommitAsync();
        }

        public async Task<int> Search(int take, int page, string searchTerm)
        {
            var client = searchRepository.GetIndexClient();

            var q = new SolrQueryByField("name", searchTerm) { Quoted = false } ||
                new SolrQueryByField("description", searchTerm) { Quoted = false } ||
                new SolrQueryByField("code", searchTerm) { Quoted = false };

            var response = await client.QueryAsync(
                q,
                new QueryOptions(){
                    StartOrCursor = new StartOrCursor.Start(take * (page - 1)),
                    Rows = take,
                });

            return response.Count();
        }

    }
}
