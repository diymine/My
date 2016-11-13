using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Mapping
{
    public class PersonMapping : EntityTypeConfiguration<Person>
    {
        public PersonMapping()
        {
            ToTable("Person");
            Property(p => p.PersonId).HasColumnName("PersonId");
            //HasOptional(o => o.Photo).WithRequired(o => o.Person);
            //HasRequired(t => t.Photo).WithRequiredPrincipal(t => t.Person);
            //并发检查
            Property(t => t.SocialSecurityNumber).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsConcurrencyToken();
            //长度50 不为空
            Property(t => t.FirstName).IsRequired().HasMaxLength(50);
            //长度50 不为空
            Property(t => t.LastName).IsRequired().HasMaxLength(50);
            //并发检查
            Property(t => t.RowVersion).IsRowVersion();
        }
    }
}
