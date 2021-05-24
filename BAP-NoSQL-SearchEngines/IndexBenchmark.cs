using BAP_NoSQL_SearchEngines.DTO;
using BAP_NoSQL_SearchEngines.Models;
using BAP_NoSQL_SearchEngines.Repositories;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BAP_NoSQL_SearchEngines
{
    [MemoryDiagnoser]
    [WarmupCount(10)]
    [IterationCount(50)]
    public class IndexBenchmark
    {
        private readonly BAPContext dbContext;
        private readonly ArticleElasticSearch articleElasticSearch;
        private readonly ArticleAzureSearch articleAzureSearch;
        private readonly ArticleSolrSearch articleSolrSearch;
        private readonly ArticleRepository articleRepository;

        public IndexBenchmark()
        {
            this.dbContext = new BAPContext();
            this.articleRepository = new ArticleRepository(dbContext);
            this.articleElasticSearch = new ArticleElasticSearch(
                new CloudElasticsearchRepository(), new LocalElasticsearchRepository(), articleRepository);

            this.articleAzureSearch = new ArticleAzureSearch(
                new AzureSearchRepository(), articleRepository);

            this.articleSolrSearch = new ArticleSolrSearch(
                new SolrSearchRepository(), articleRepository);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        #region Index Benchmark
        [Benchmark(Baseline = true)]
        public async Task CloudElasticBuildIndex()
        {
            await articleElasticSearch.RebuildIndex(true);
        }

        [Benchmark]
        public async Task LocalElasticBuildIndex()
        {
            await articleElasticSearch.RebuildIndex(false);
        }

        [Benchmark]
        public async Task AzureBuildIndex()
        {
            await articleAzureSearch.RebuildIndex();
        }

        [Benchmark]
        public async Task SolrBuildIndex()
        {
            await articleSolrSearch.RebuildIndex();
        }
        #endregion
    }

    [MemoryDiagnoser]
    [WarmupCount(10)]
    [IterationCount(50)]
    public class SearchBenchmark
    {
        private readonly BAPContext dbContext;
        private readonly ArticleElasticSearch articleElasticSearch;
        private readonly ArticleAzureSearch articleAzureSearch;
        private readonly ArticleSolrSearch articleSolrSearch;
        private readonly ArticleRepository articleRepository;

        public SearchBenchmark()
        {
            this.dbContext = new BAPContext();
            this.articleRepository = new ArticleRepository(dbContext);
            this.articleElasticSearch = new ArticleElasticSearch(
                new CloudElasticsearchRepository(), new LocalElasticsearchRepository(), articleRepository);

            this.articleAzureSearch = new ArticleAzureSearch(
                new AzureSearchRepository(), articleRepository);

            this.articleSolrSearch = new ArticleSolrSearch(
                new SolrSearchRepository(), articleRepository);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }


        #region Query Benchmark

        [Benchmark(Baseline = true)]
        [Arguments(10, 1, "VPE=10")]
        [Arguments(250, 3, "VPE=10")]
        [Arguments(10, 1, "*")]
        [Arguments(250, 3, "*")]
        [Arguments(10, 1, "dompelpomp || 400V")]
        [Arguments(250, 12, "dompelpomp || 400V")]
        public async Task CloudElasticQueryExecution(int take, int page, string searchTerm)
        {
            int amountOfResults = await articleElasticSearch.Search(take, page, searchTerm, true);
            Console.WriteLine($"amount of results: {amountOfResults}");
        }

        [Benchmark]
        [Arguments(10, 1, "VPE=10")]
        [Arguments(250, 3, "VPE=10")]
        [Arguments(10, 1, "*")]
        [Arguments(250, 3, "*")]
        [Arguments(10, 1, "dompelpomp || 400V")]
        [Arguments(250, 12, "dompelpomp || 400V")]
        public async Task LocalElasticQueryExecution(int take, int page, string searchTerm)
        {
            int amountOfResults = await articleElasticSearch.Search(take, page, searchTerm, false);
            Console.WriteLine($"amount of results: {amountOfResults}");
        }

        [Benchmark]
        [Arguments(10, 1, "VPE=10")]
        [Arguments(250, 3, "VPE=10")]
        [Arguments(10, 1, "*")]
        [Arguments(250, 3, "*")]
        [Arguments(10, 1, "dompelpomp || 400V")]
        [Arguments(250, 12, "dompelpomp || 400V")]
        public async Task AzureQueryExecution(int take, int page, string searchTerm)
        {
            int amountOfResults = await articleAzureSearch.Search(take, page, searchTerm);
            Console.WriteLine($"amount of results: {amountOfResults}");
        }

        [Benchmark]
        [Arguments(10, 1, "VPE=10")]
        [Arguments(250, 3, "VPE=10")]
        [Arguments(10, 1, "*")]
        [Arguments(250, 3, "*")]
        [Arguments(10, 1, "dompelpomp || 400V")]
        [Arguments(250, 12, "dompelpomp || 400V")]
        public async Task SolrQueryExecution(int take, int page, string searchTerm)
        {
            int amountOfResults = await articleSolrSearch.Search(take, page, searchTerm);
            Console.WriteLine($"amount of results: {amountOfResults}");
        }
        #endregion

    }
}
