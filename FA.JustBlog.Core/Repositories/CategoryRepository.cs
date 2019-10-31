using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Interfaces;
using FA.JustBlog.Models;

namespace FA.JustBlog.Repositories
{
    class CategoryRepository : ICategoryRepository
    {
        private readonly JustBlogContext db;
        public CategoryRepository()
        {
            db = new JustBlogContext();
        }
        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public Category Find(int categoryId)
        {
            Category category = db.Categories.Find(categoryId);
            return category;

        }

        public void UpdateCategory(Category category)
        {
            var uCategory = db.Categories.Where(c => c.Id == category.Id).First();
            uCategory = category;
            db.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            db.Categories.Remove(category);
            // db.Entry(category).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            db.Categories.Remove(db.Categories.Find(categoryId));
            //db.Entry(categoryId).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public IList<Category> GetAllCategories()
        {
            return db.Categories.ToList<Category>();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
