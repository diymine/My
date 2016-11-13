using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PersonPhoto
    {
        public int PersonId { get; set; }
        public byte[] Photo { get; set; }
        public string Caption { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
}
