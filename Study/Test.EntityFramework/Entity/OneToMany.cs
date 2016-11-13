using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Blog
   {
        public Blog()
        {
            Posts = new List<Post>();
        }

        public int Id { get; set; }
        public string ShortDescription { get; set; }
        public string Title { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Nullable<int> BlogId { get; set; }
        public virtual Blog Blog { get; set; }

        //public int PrimaryAuthorId { get; set; }
        //public virtual Author PrimaryAuthor { get; set; }
        //public Nullable<int> SecondaryAuthorId { get; set; }
        //public virtual Author SecondaryAuthor { get; set; }
    }

    //public class Author
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Email { get; set; }
    //    //个人简历
    //    public string Bio { get; set; }

    //    public List<Post> PrimaryAuthorFor { get; set; }
    //    public List<Post> SecondaryAuthorFor { get; set; }
    //}
}