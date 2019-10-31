using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Models
{
   public class JustBlogContext : DbContext
    {
        //Ex. 5
        public JustBlogContext() : base("FA.JustBlog.Core")
        {
            Database.SetInitializer(new JustBlogInitializer());

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> comments { get; set; }

        // Ex. 4
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasMany<Tag>(p => p.Tags).WithMany(t => t.Posts).Map(tp =>
            {
                tp.MapLeftKey("PostId");
                tp.MapRightKey("TagId");
                tp.ToTable("PostTagMap");
            });

        }
    }

}
