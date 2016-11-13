using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DropCreateDatabaseStrategy : DropCreateDatabaseAlways<EntityContext>
    {
        public DropCreateDatabaseStrategy()
        {
        }

        //创建数据库时 Seed数据
        protected override void Seed(EntityContext context)
        {
            context.Persons.Add(new Person()
            {
                FirstName = "E",
                LastName = "F",
                SocialSecurityNumber = 123456,
                Photo = new PersonPhoto()
                {
                    Caption = "这是照片",
                    Photo = new byte[] { }
                }
            });
            context.Blogs.Add(new Blog()
            {
                Id = 1,
                Title = "test",
                Posts = new List<Post>()
                {
                    new Post()
                    {
                        Id =1,
                        Title = "title1",
                        Content = "content1"
                    },
                    new Post()
                    {
                        Id =2,
                        Title = "title2",
                        Content = "content2"
                    }
                }
            });
            context.SaveChanges();
        }
    }
}
