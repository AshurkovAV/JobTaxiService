using JobTaxi.Entity.Dto.User;

namespace JobTaxi.Entity.Dto.Park
{
    public class ParkQueryDto
    {
        public int                    UserId          { get; set; }
        public List<SelectAuto>?      AutoClass       { get; set; }
        public List<SelectLocation>?  LocationFilter  { get; set; }
        public bool?                  Ransom          { get; set; }
    }
}
