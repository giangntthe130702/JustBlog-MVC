using FA.JustBlog.Core;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Interfaces;
using FA.JustBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly JustBlogContext db;

        public PostRepository()
        {
            db = new JustBlogContext();
        }

        public void AddPost(Post post)
        {
            db.Posts.Add(post);
            db.SaveChanges();
        }

        public int CountPostsForCategory(string category)
        {
            return db.Categories.Where(p => p.Name.Equals(category)).Count();
        }

        public int CountPostsForTag(string tag)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(Post post)
        {
            db.Posts.Remove(post);
            db.SaveChanges();
        }

        public void DeletePost(int postId)
        {
            db.Posts.Remove(db.Posts.Find(postId));
            db.SaveChanges();
        }

        public Post FindPost(int year, int month, string urlSlug)
        {
            List<Post> list = db.Posts.ToList<Post>();
            foreach (Post p in list)
            {
                if (p.UrlSlug.Equals(urlSlug) && p.PostOn.Year == year && p.PostOn.Month == month)
                    return p;
            }
            return null;
        }

        public Post FindPost(int postId)
        {
            return db.Posts.Find(postId);
        }

        public IList<Post> GetAllPosts()
        {
            return db.Posts.ToList<Post>();
        }

        public IList<Post> GetHighestPosts(int size)
        {
            return db.Posts.OrderBy(p => p.Rate).Take(size).ToList();
        }

        public IList<Post> GetLatestPost(int size)
        {            
            return db.Posts.OrderByDescending(p => p.PostOn).Take(size).ToList();
        }

        public IList<Post> GetMostViewedPost(int size)
        {
            return db.Posts.OrderByDescending(p => p.ViewCount).Take(size).ToList();
        }

        public IList<Post> GetPostsByCategory(string category)
        {
            List<Post> list = db.Posts.ToList<Post>();
            foreach (Post p in list)
            {
                if (p.Category.Equals(category))
                {
                    list.Add(p);
                    return list;
                }           
            }
            return null;
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return db.Posts.Where(p => p.PostOn.Month == monthYear.Month).ToList();
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            return db.Tags.Where(t => t.Name == tag).FirstOrDefault().Posts;
        }

        public IList<Post> GetPublisedPosts()
        {
            throw new NotImplementedException();
        }

        public IList<Post> GetUnpublisedPosts()
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(Post post)
        {
            var uPost = db.Posts.Where(p => p.Id == post.Id).First();
            uPost = post;
            db.SaveChanges();
        }
    }
}
