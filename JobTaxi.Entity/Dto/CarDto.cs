namespace JobTaxi.Entity.Dto
{
    public class CarDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Number { get; set; }
        public int? Year { get; set; }
        public double? PriceForDay { get; set; }
        public string ShemaName { get; set; }
        public string ClassName { get; set; }
    }
}
