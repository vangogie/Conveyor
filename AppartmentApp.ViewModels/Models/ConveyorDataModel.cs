using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor.ViewModels.Models
{
    public class ConveyorDataModel
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public double Speed { get; set; }
        public double Mass { get; set; }
        public double Angle { get; set; }
        public string BeltType { get; set; }
        public string Enginetype { get; set; }
        public string ConveyorMaterial { get; set; }
        public bool HasFrame { get; set; }
        public string FrameMaterial { get; set; }
        public double FrameHeight { get; set; }
    }
}
