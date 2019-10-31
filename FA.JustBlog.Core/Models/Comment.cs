using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Models
{
  public  class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Post Post { get; set; }
        public string CommentHeader { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentTime { get; set; }


    }
}
