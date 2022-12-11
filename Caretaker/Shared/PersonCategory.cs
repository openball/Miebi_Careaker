using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caretaker.Shared
{
    public class PersonCategory
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonCategoryId { get; set; }
        public string CategoryDesc { get; set; }
        //public ICollection<Person> People { get; set; }
    }
}
