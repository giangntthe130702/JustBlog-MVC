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
    class CommentRepository : ICommentRepository
    {
        private readonly JustBlogContext db;
        public CommentRepository()
        {
            db = new JustBlogContext();
        }

        public void AddComment(Comment comment)
        {
            db.comments.Add(comment);
            db.SaveChanges();
        }

        public void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            Comment c = new Comment();
            c.Id = postId;
            c.Name = commentName;
            c.Email = commentEmail;
            c.CommentHeader = commentTitle;
            c.CommentText = commentBody;
            c.CommentTime = DateTime.Now;

            db.comments.Add(c);
            db.SaveChanges();
        }

        public void DeleteComment(Comment comment)
        {
            db.comments.Remove(comment);
        }

        public void DeleteComment(int commendId)
        {
            Comment c = (Comment) db.comments.Where(p => p.Id == commendId);
            db.comments.Remove(c);
            db.SaveChanges();
        }

        public Comment Find(int commentId)
        {
            return db.comments.Find(commentId);
        }

        public IList<Comment> GetAllComments()
        {
            return db.comments.ToList();
        }

        public IList<Comment> GetCommentsForPost(int postId)
        {
            return db.comments.Where(p => p.Id == postId).ToList();
        }

        public IList<Comment> GetCommentsForPost(Post post)
        {
            return db.comments.Where(p => p.Id == post.Id).ToList();
        }

        public void UpdateComment(Comment comment)
        {
            var uComment = db.comments.Where(p => p.Id == comment.Id).First();
            uComment = comment;
            db.SaveChanges();
        }
    }
}
