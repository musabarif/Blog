using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewBlog.Models
{
    public class Post
    {
        internal bool id;

        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public Author AuthorName { get; set; }
        public List<Tags> Tags { get; set; }
        public int Views { get; set; }


        public Post()
        {
            this.Views = 0;
        }
    }
}