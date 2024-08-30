namespace JobTaxi.Entity.Dto.User;

public partial class UsersFilterDto :BaseDto
{
    public int                       Id                      { get; set; }
    public string                    FilterName              { get; set; } = null!;
    public string?                   AddressLatitude         { get; set; }
    public string?                   AddressLongitude        { get; set; }
    public double?                   ParkPercent             { get; set; }
    public int                       FilterUserId            { get; set; }
    public bool?                     IsPush                  { get; set; } = true;
    public List<SelectAuto>?         AutoClass               { get; set; }
    public List<SelectLocation>?     LocationFilter          { get; set; }
    public bool                      Ransom                  { get; set; }
}
