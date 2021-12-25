using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppartmentApp.DataAccess.Entities
{
    public class ConveyorBelt : BaseEntity
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        public double Cost { get; set; }
        public BeltType BeltType { get; set; }
    }
}
