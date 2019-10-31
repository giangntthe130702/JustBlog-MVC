using FA.JustBlog.Core.Models;
using FA.JustBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog
{
    class JustBlogInitializer : CreateDatabaseIfNotExists<JustBlogContext>
    {
        protected override void Seed(JustBlogContext context)
        {
            IList<Category> categories = new List<Category>();
            IList<Post> posts = new List<Post>();
            IList<Tag> tags = new List<Tag>();

            Category c1 = new Category() { Id = 1, Name = "Technology", UrlSlug = "blogger.com/TechnologyCategory", Description = "Technology News" };
            Category c2 = new Category() { Id = 2, Name = "Cooking", UrlSlug = "blogger.com/CookingCategory", Description = "How to cook" };
            Category c3 = new Category() { Id = 3, Name = "Travelling", UrlSlug = "blogger.com/TravellingCategory", Description = "Place to go" };

            Post p1 = new Post() { Id = 1, Title = "Daily Technology", Description = "Finish", PostContent = "Apple release Iphone XI", UrlSlug = "blogger.com/TechnologyCategory/Daily-Technology", Published = "Unknow", PostOn = DateTime.Parse("2019/09/09"), Modified = "none", CategoryId = 1, ViewCount = 50, RateCount = 40, TotalRate = 40, Rate = 40 };
            Post p2 = new Post() { Id = 2, Title = "Baking Tiramisu", Description = "", PostContent = "Cooking Step", UrlSlug = "blogger.com/CookingCategory/Baking-Tiramisu", Published = "Chef Gordon", PostOn = DateTime.Parse("2019/10/10"), Modified = "", CategoryId = 2, ViewCount = 40, RateCount = 30, TotalRate = 30, Rate = 30 };
            Post p3 = new Post() { Id = 3, Title = "Life in South Asia", Description = "List place", PostContent = "Place to visit in South Asia", UrlSlug = "blogger.com/TravellingCategory/South-Asia", Published = "Ellen Traveller", PostOn = DateTime.Parse("2019/09/20"), Modified = "Change Title", CategoryId = 3, ViewCount = 40, RateCount = 20, TotalRate = 20, Rate = 20 };

            Tag t1 = new Tag() { Id = 1, Name = "Technology", UrlSlug = "blogger.com/Technology", Description = "technology tag", Count = 2 };
            Tag t2 = new Tag() { Id = 2, Name = "Cooking", UrlSlug = "blogger.com/Cooking", Description = "cooking tag", Count = 3 };
            Tag t3 = new Tag() { Id = 3, Name = "Travelling", UrlSlug = "blogger.com/Travelling", Description = "", Count = 4 };

            c1.Posts = new List<Post> { p1 };
            c2.Posts = new List<Post> { p2 };
            c3.Posts = new List<Post> { p3 };

            p1.Tags = new List<Tag> { t1 };
            p2.Tags = new List<Tag> { t2 };
            p3.Tags = new List<Tag> { t3 };

            t1.Posts = new List<Post> { p1 };
            t2.Posts = new List<Post> { p2 };
            t3.Posts = new List<Post> { p3 };

            categories.Add(c1);
            categories.Add(c2);
            categories.Add(c3);

            posts.Add(p1);
            posts.Add(p2);
            posts.Add(p3);

            tags.Add(t1);
            tags.Add(t1);
            tags.Add(t1);

            context.Categories.AddRange(categories);
            context.Posts.AddRange(posts);
            context.Tags.AddRange(tags);

            base.Seed(context);
        }
    }
}
