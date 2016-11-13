using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Mapping
{
    internal class BlogMapping : EntityTypeConfiguration<Blog>
    {
        public BlogMapping()
        {
            this.HasMany(o => o.Posts).WithOptional(o => o.Blog).HasForeignKey(o => o.BlogId);
        }
    }
    internal class PostMapping : EntityTypeConfiguration<Post>
    {
        public PostMapping()
        {
            this.HasOptional(o => o.Blog).WithMany(o => o.Posts).HasForeignKey(o => o.BlogId);
            Property(t => t.Content).IsRequired();
        }
    }
}
