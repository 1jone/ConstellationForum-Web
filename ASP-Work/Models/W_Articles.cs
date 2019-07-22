namespace ASP_Work.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class W_Articles
    {
        public int Id { get; set; }

        [Column(TypeName = "text")]
        public string ImgUrl { get; set; }

        [StringLength(300)]
        public string Title { get; set; }

        public string Content { get; set; }

        [StringLength(300)]
        public string Label { get; set; }

        [StringLength(600)]
        public string Brief { get; set; }

        [StringLength(50)]
        public string TUserName { get; set; }

        [StringLength(50)]
        public string ArticleCategory { get; set; }

        [StringLength(50)]
        public string ArticleParentcategory { get; set; }

        public int? IsTop { get; set; }

        public DateTime? AddTime { get; set; }

        public int? Hits { get; set; }

        [StringLength(50)]
        public string Source { get; set; }

        public int? CommentCount { get; set; }
    }
}
