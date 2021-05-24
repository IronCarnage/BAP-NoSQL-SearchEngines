using BAP_NoSQL_SearchEngines.DTO;
using BAP_NoSQL_SearchEngines.IRepositories;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAP_NoSQL_SearchEngines.Repositories
{
    public class ArticleElasticSearch
    {
        private readonly CloudElasticsearchRepository cloudSearchRepository;
        private readonly LocalElasticsearchRepository localSearchRepository;
        private readonly ArticleRepository articleRepository;

        public ArticleElasticSearch(CloudElasticsearchRepository cloudSearchRepository, LocalElasticsearchRepository localSearchRepository, ArticleRepository articleRepository)
        {
            this.cloudSearchRepository = cloudSearchRepository;
            this.localSearchRepository = localSearchRepository;
            this.articleRepository = articleRepository;
        }

        public async Task CloudCreateOrDropAndCreateIndex()
        {
            await cloudSearchRepository.CreateIndexIfNotExists<ArticleDTO>();
        }public async Task LocalCreateOrDropAndCreateIndex()
        {
            await localSearchRepository.CreateIndexIfNotExists<ArticleDTO>();
        }

        public async Task RebuildIndex(bool cloud)
        {
            if (cloud)
            {
                await CloudCreateOrDropAndCreateIndex();
            }
            else
            {
                await LocalCreateOrDropAndCreateIndex();
            }
            await IndexArticles(cloud);
        }

        private async Task IndexArticles(bool cloud)
        {
            IElasticClient client;

            if (cloud)
            {
                client = cloudSearchRepository.GetIndexClient();
            }
            else
            {
                client = localSearchRepository.GetIndexClient();
            }

            List<ArticleDTO> articles = articleRepository.GetAllArticles();
            double currentTotal = 0;
            double totalCount = articles.Count();

            while (currentTotal < totalCount)
            {
                BulkResponse bulkResponse = await client.BulkAsync(b => b.IndexMany((articles.Skip((int)currentTotal).Take(1000))));

                if (bulkResponse.Errors)
                {
                    foreach (var itemWithError in bulkResponse.ItemsWithErrors)
                    {
                        Console.WriteLine($"Failed to index document {itemWithError.Id}: {itemWithError.Error}");
                    }
                }

                currentTotal += 1000;
            }
        }

        public async Task<int> Search(int take, int page, string searchTerm, bool cloud)
        {
            IElasticClient client;

            if (cloud)
            {
                client = cloudSearchRepository.GetIndexClient();
            }
            else
            {
                client = localSearchRepository.GetIndexClient();

            }

            var result = new List<ArticleDTO>();

            searchTerm = searchTerm.Replace("=", " ");

            var response = await client.SearchAsync<ArticleDTO>(s => s
                    .Take(take)
                    .Query(q => 
                        q.QueryString(mm => mm
                            .Query(searchTerm)
                            )
                    )
                    .Scroll("1m")
                );

            long totalhits = response.Total;
            int currentPage = 1;

            //to allow for pagination while scrolling the documents
            while (response.IsValid)
            {
                if (currentPage == page)
                {
                    result.AddRange(response.Documents.Select(e => e));
                    client.ClearScroll(new ClearScrollRequest(response.ScrollId));
                }
                response = await client.ScrollAsync<ArticleDTO>(new ScrollRequest(response.ScrollId, "1m"));

                currentPage++;
            }

            // return amount of results, more important than the actual objects that where returned
            return result.Count();
        }
    }
}
