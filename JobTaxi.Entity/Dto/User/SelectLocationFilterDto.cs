namespace JobTaxi.Entity.Dto.User
{
    public class SelectLocationFilterDto: BaseDto
    {
        public List<int> LocationIds  { get; set; }
        public int       UserId       { get; set; }
        public int       UserFilterId { get; set; }
    }
}
