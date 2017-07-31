using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewBlog.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
    }
}