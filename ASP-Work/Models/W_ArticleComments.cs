namespace ASP_Work.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class W_ArticleComments
    {
        public int Id { get; set; }

        public string User { get; set; }

        public int? ArticleId { get; set; }

        public int? IsPraise { get; set; }

        public string Content { get; set; }

        public DateTime? CreateTime { get; set; }

        public bool? IsAdopt { get; set; }

        public long? Ticks { get; set; }

        public int? IsLike { get; set; }

        [StringLength(50)]
        public string TimeAgo { get; set; }
    }
}
