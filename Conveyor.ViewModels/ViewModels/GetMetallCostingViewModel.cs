using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor.ViewModels.ViewModels
{
    public class GetMetallCostingViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set;}
    }
}
