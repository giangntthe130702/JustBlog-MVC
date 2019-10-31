using FA.JustBlog.Interfaces;
using FA.JustBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly JustBlogContext db;
        public TagRepository()
        {
            db = new JustBlogContext();
        }

        public Tag Find(int TagId)
        {
            List<Tag> list = db.Tags.ToList<Tag>();
            foreach (Tag t in list)
            {
                if (t.Id == TagId)
                    return t;
            }
            return null;
        }

        public void AddTag(Tag tag)
        {
            db.Tags.Add(tag);
            db.SaveChanges();
        }

        public void DeleteTag(Tag tag)
        {
            db.Tags.Remove(tag);
            db.SaveChanges();
        }

        public void DeleteTag(int tagId)
        {
            db.Tags.Remove(db.Tags.Find(tagId));
            db.SaveChanges();
        }
        public void UpdateTag(Tag Tag)
        {
            var uTag = db.Tags.Where(t => t.Id == Tag.Id).First();
            uTag = Tag;
            db.SaveChanges();
        }

        public IList<Tag> GetAllTags()
        {
            return db.Tags.ToList<Tag>();
        }

        
        public Tag GetTagByUrlSlug(string urlSlug)
        {
            
            return db.Tags.SingleOrDefault(t=>t.UrlSlug.Equals(urlSlug));
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
