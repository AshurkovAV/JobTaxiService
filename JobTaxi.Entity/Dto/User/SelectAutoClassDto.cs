namespace JobTaxi.Entity.Dto.User
{
    public class SelectAutoClassDto: BaseDto
    {
        public List<int> AutoClassIds   { get; set; }
        public int       UserId         { get; set; }
        public int       UserFilterId   { get; set; }
    }
}
