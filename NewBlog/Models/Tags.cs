using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewBlog.Models
{
    public class Tags
    {
       [Key]
        public int TagID { get; set; }
        public string Name { get; set; }
    }
}