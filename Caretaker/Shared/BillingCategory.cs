using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caretaker.Shared
{
    public class BillingCategory
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillingCategoryId { get; set; }
        [Required]
        public int TransactionTypeID { get; set; }
        public TransactionType TransactionType { get; set; }
        public string? Description { get; set; }
        public double Amount { get; set; }
        //public ICollection<Apartment> Apartments { get; set; }
    }
}
