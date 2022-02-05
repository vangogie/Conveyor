using System.ComponentModel.DataAnnotations;

namespace Conveyor.DataAccess.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
