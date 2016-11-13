using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Mapping
{
    class PersonPhotoMapping : EntityTypeConfiguration<PersonPhoto>
    {
        public PersonPhotoMapping()
        {
            HasKey(t => t.PersonId);
            //长度50
            Property(t => t.Caption).HasMaxLength(50);
            ////必须从属于Person
            //HasRequired(t => t.Person)
            //    .WithRequiredDependent(t => t.Photo)
            //    .Map(config => config.MapKey("Fk_person_personphone"));
            HasRequired(t => t.Person).WithRequiredDependent(t => t.Photo);
        }
    }
}
