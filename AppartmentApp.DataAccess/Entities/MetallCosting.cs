using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppartmentApp.DataAccess.Entities
{
    public class MetallCosting : BaseEntity
    {
        [MaxLength(25)]
        [Required]
        public string Name { get; set; }
        [Required]
        public double Cost { get; set;}
    }
}
