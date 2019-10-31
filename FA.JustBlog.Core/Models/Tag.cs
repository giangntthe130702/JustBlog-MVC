using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tag name is required.")]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string UrlSlug { get; set; }
        [StringLength(1024)]
        public string Description { get; set; }
        public int Count { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }
}
