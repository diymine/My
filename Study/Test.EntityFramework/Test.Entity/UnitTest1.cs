using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Entity
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Stopwatch wa = new Stopwatch();
            wa.Start();
            using (var db = new EntityContext())
            {
                db.TestTable.Add(new TestTable(){Id = 1,Name = "test"});
                db.SaveChanges();
            }
            wa.Stop();
            Console.WriteLine(wa.ElapsedMilliseconds);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Stopwatch wa = new Stopwatch();
            wa.Start();
            using (var db = new EntityContext())
            {
                db.Database.ExecuteSqlCommand("INSERT INTO TestTables VALUES('TEATA')");
            }
            wa.Stop();
            Console.WriteLine(wa.ElapsedMilliseconds);
        }

        [TestMethod]
        public void TestQuery()
        {
            Stopwatch wa = new Stopwatch();
            wa.Start();
            using (var db = new EntityContext())
            {
                var query = from item in db.TestTable where item.Id == 2 select item ;
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

            }
            wa.Stop();
            Console.WriteLine(wa.ElapsedMilliseconds);
        }
        [TestMethod]
        public void TestExpression()
        {
            Stopwatch wa = new Stopwatch();
            wa.Start();
            using (var db = new EntityContext())
            {
                var query = from item in db.TestTable where item.Id == 2 select item;
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

            }
            wa.Stop();
            Console.WriteLine(wa.ElapsedMilliseconds);
        }

        [TestMethod]
        public void ShouldReturnAPersonWithPhoto()
        {
            //Arrange
            var init = new DropCreateDatabaseStrategy();
            Person person;
            using (var context = new EntityContext())
            {
                init.InitializeDatabase(context);
                //Act
                //person = context.Persons.Include(t => t.Photo).FirstOrDefault();
                person = context.Persons.FirstOrDefault();
            }
            //Assert
            Assert.IsNotNull(person);
            Assert.IsNotNull(person.Photo);
        }


        [TestMethod]
        public void TestUpdateOneToOne()
        {
            using (var context = new EntityContext())
            {
                var person = context.Persons.Include(o => o.Photo).FirstOrDefault();
                Assert.IsNotNull(person);
                person.FirstName = "caohaijun";
                person.LastName = "haijun";
                Assert.IsNotNull(person.Photo);
                person.Photo.Caption = "更新照片";
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestUpdateOneToMany()
        {
            using (var context = new EntityContext())
            {
                var blog = context.Blogs.Include("Posts").FirstOrDefault();
                Assert.IsNotNull(blog);
                blog.Title = "caohaijun";
                Assert.IsNotNull(blog.Posts);
                Assert.IsNotNull(blog.Posts[0]);
                blog.Posts[0].Title = "更新照片";
                blog.Posts.Add(new Post()
                {
                    Id = 3,
                    Title = "update add"
                });
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestUpdateOneToManyRemove()
        {
            using (var context = new EntityContext())
            {
                var blog = context.Blogs.Include("Posts").FirstOrDefault();
                Assert.IsNotNull(blog);
                blog.Title = "caohaijun";
                Assert.IsNotNull(blog.Posts);
                Assert.IsNotNull(blog.Posts[0]);
                blog.Posts.Remove(blog.Posts[0]);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestAttachBlog()
        {
            using (var context = new EntityContext())
            {
                var blogAttach = new Blog();
                blogAttach.Id = 1;
                blogAttach.Title = "caohaijun2";
                //blogAttach.Posts = new List<Post>(){new Post(){Content = "fffff",BlogId = 1,Id = 1,Title = "aaaa"}};
                context.Blogs.Attach(blogAttach);
                context.Entry(blogAttach).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestAttachPost()
        {
            using (var context = new EntityContext())
            {
                var postAttach = new Post();
                postAttach.Id = 1;
                postAttach.Title = "caohaijun2";
                postAttach.BlogId = 1;
                postAttach.Content = "aaaa";
                //postAttach.Blog = new Blog();
                context.Posts.Attach(postAttach);
                context.Entry(postAttach).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void Replace()
        {
            string a = @"aaa\aaab";
            Console.WriteLine(a.Replace("\\","\\\\"));
            Console.WriteLine("\a");
            Console.WriteLine("\\a");
            Console.WriteLine("\\你");
            //Regex.Replace("aaa\aaab", "", "");
        }
    }
}
