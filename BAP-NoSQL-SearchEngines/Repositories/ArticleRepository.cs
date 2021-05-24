using BAP_NoSQL_SearchEngines.DTO;
using BAP_NoSQL_SearchEngines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAP_NoSQL_SearchEngines.Repositories
{
    public class ArticleRepository
    {

        private readonly BAPContext dbContext;

        public ArticleRepository(BAPContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ArticleDTO> GetAllArticles()
        {
            IQueryable<ArticleDTO> articles = (from a in dbContext.Articles
                                               where !a.IsDeleted
                                               select new ArticleDTO
                                               {
                                                   Id = a.Id.ToString(),
                                                   Name = a.Name,
                                                   Code = a.Code.Replace("-", " "),
                                                   Description = a.Description.Replace("-", " "),
                                                   BasePrice = (double)(a.BasePrice.HasValue ? a.BasePrice.Value: 0),
                                                   BaseNettoPrice = (double)(a.BaseNettoPrice.HasValue ? a.BaseNettoPrice.Value : 0),
                                                   ExternalLink = a.ExternalLink,
                                                   IsArticleGroup = (bool)a.IsArticleGroup,
                                                   IsCommon = (bool)a.IsCommon,
                                                   BarCode = a.BarCode.Replace("-", " "),
                                                   ArticleType = (int)a.ArticleType,
                                                   Ean = !string.IsNullOrEmpty(a.Ean)? a.Ean : "",
                                               });
            return articles.ToList();
        }
    }
}
