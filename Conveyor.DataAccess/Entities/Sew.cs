using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor.DataAccess.Entities
{
    public class Sew : BaseEntity
    {
        [Required]
        public double Power { get; set; }
        [Required]
        public int Cost { get; set; }
    }
}
