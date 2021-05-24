namespace BAP_NoSQL_SearchEngines.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Articles
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Code { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? BasePrice { get; set; }

        public decimal? BaseNettoPrice { get; set; }

        public string ExternalLink { get; set; }

        public bool? IsArticleGroup { get; set; }

        public bool? IsCommon { get; set; }

        public string BarCode { get; set; }

        public bool IsDeleted { get; set; }

        public int? ArticleType { get; set; }

        public string Ean { get; set; }
    }
}
