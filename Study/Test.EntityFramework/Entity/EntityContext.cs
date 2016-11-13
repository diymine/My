using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Mapping;

namespace Entity
{
    public class EntityContext:DbContext
    {
        public EntityContext() : base("Entity")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonMapping());
            modelBuilder.Configurations.Add(new PersonPhotoMapping());
            modelBuilder.Configurations.Add(new BlogMapping());
            modelBuilder.Configurations.Add(new PostMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TestTable> TestTable { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonPhoto> Photos { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}
