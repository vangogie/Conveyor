namespace Conveyor.ViewModels.ViewModels
{
    public class GetConveyorBeltViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public GetBeltTypeViewModel BeltType { get; set; }
    }
}
