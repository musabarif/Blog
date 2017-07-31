using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewBlog.Models
{
    public class NewBlogDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public NewBlogDBContext() : base("name=NewBlogDBContext")
        {
            Database.SetInitializer<NewBlogDBContext>(new DropCreateDatabaseIfModelChanges<NewBlogDBContext>());
        }
        public System.Data.Entity.DbSet<NewBlog.Models.Post> Posts { get; set; }
         public System.Data.Entity.DbSet<NewBlog.Models.Tags> Tags { get; set; }
        public System.Data.Entity.DbSet<NewBlog.Models.Author> Authors { get; set; }
    }
}
