using BAP_NoSQL_SearchEngines.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAP_NoSQL_SearchEngines.IRepositories
{
    interface IArticleRepository
    {
        Task<ArticleDTO> GetAllArticles();
    }
}
