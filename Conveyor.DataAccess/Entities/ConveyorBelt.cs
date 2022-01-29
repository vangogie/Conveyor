using System.ComponentModel.DataAnnotations;

namespace Conveyor.DataAccess.Entities
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
