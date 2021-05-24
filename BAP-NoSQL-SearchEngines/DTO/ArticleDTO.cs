using Azure.Search.Documents.Indexes;
using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAP_NoSQL_SearchEngines.DTO
{
    public class ArticleDTO
    {
        [System.ComponentModel.DataAnnotations.Key]
        [SolrUniqueKey("id")]
        public string Id { get; set; }
        [SolrField("code")]
        [SearchableField]
        public string Code { get; set; }
        [SolrField("name")]
        [SearchableField]
        public string Name { get; set; }
        [SolrField("description")]
        [SearchableField]
        public string Description { get; set; }
        [SolrField("base_price")]
        public double BasePrice { get; set; }
        [SolrField("base_netto_price"), ]
        public double BaseNettoPrice { get; set; }
        [SolrField("external_link")]
        [SearchableField]
        public string ExternalLink { get; set; }
        [SolrField("is_article_group")]
        public bool IsArticleGroup { get; set; }
        [SolrField("is_common")]
        public bool IsCommon { get; set; }
        [SolrField("bar_code")]
        [SearchableField]
        public string BarCode { get; set; }
        [SolrField("article_type")]
        public int ArticleType { get; set; }
        [SolrField("ean")]
        [SearchableField]
        public string Ean { get; set; }

    }
}
