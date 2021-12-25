using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppartmentApp.DataAccess.Entities
{
    public class BeltType : BaseEntity
    {
        [MaxLength(15)]
        [Required]
        public string Type { get; set; }
        public ICollection<ConveyorBelt> ConveyorBelts { get; set; }
    }
}
