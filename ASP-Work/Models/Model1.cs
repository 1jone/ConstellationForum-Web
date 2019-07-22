namespace ASP_Work.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<W_ArticleComments> W_ArticleComments { get; set; }
        public virtual DbSet<W_Articles> W_Articles { get; set; }
        public virtual DbSet<W_Users> W_Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<W_ArticleComments>()
                .Property(e => e.TimeAgo)
                .IsUnicode(false);

            modelBuilder.Entity<W_Articles>()
                .Property(e => e.ImgUrl)
                .IsUnicode(false);
        }
    }
}
