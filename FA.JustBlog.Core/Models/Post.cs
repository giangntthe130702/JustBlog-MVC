using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FA.JustBlog.Models;

namespace FA.JustBlog.Core.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(255)]
        public string Title { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [StringLength(255)]
        public string PostContent { get; set; }
        [StringLength(255)]
        public string UrlSlug { get; set; }
        [StringLength(255)]
        public string Published { get; set; }
        public DateTime PostOn { get; set; }
        [StringLength(255)]
        public string Modified { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        // Ex. 7
        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public int TotalRate { get; set; }
        public Double Rate { get; set; }

        public virtual Category Category { get; set; }

        public virtual IList<Tag> Tags { get; set; }

       


    }
}
