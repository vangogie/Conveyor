using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor.ViewModels.ViewModels
{
    public class GetSewViewModel
    {
        public int Id { get; set; }
        public double Power { get; set; }
        public int Cost { get; set; }
    }
}
