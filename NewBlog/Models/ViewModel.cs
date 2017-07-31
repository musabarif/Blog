using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewBlog.Models
{
    public class ViewModel
    {
        public Post post { get; set; }
        public List<Comment> comment { get; set; }
    }
}