using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
   public class SortPostDesc : IComparer<Post>
    {
        public int Compare(Post x, Post y)
        {
            return DateTime.Compare(y.PostOn, x.PostOn);
        }
    }

    public class SortPostByView : IComparer<Post>
    {
        public int Compare(Post x, Post y)
        {
            Post a = (Post)x;
            Post b = (Post)y;

            if(a.ViewCount < b.ViewCount)
            {
                return 1;
            }
            if(a.ViewCount > b.ViewCount)
            {
                return -1;
            } 
            else
            {
                return 0;
            }
        }
    }
}
