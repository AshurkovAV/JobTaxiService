namespace JobTaxi.Entity.Dto
{
    public class ParkTruncated
    {
        public int Id { get; set; }

        public string ParkName { get; set; } = null!;

        public string ParkAddress { get; set; } = null!; 

        public DateTime CreatedAt { get; set; }
       
        public string ParkPhone { get; set; } = null!;
         public byte[] CarAvatar { get; set; }
        public int CountCars { get; set; }

        
    }
}
