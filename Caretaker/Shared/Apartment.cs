using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caretaker.Shared
{
    public class Apartment
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApartmentId { get; set; }
        [Required]
        public string ApartmentTag { get; set; }
        public int ApartmentTypeId { get; set; }
        public ApartmentType ApartmentType { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
        [Required]
        public int BillingCategoryId { get; set; }
        public BillingCategory BillingCategory { get; set; }
        public bool Occupied { get; set; } = false; 
        public int OccupiedBy { get; set; }

    }
}
