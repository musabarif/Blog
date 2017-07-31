using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewBlog.Models
{
    public class Author
    {
        [Key]
        public int ID { get; set; }
        public string Author_Name { get; set; }
        public string Expertise { get; set; }
    }
}