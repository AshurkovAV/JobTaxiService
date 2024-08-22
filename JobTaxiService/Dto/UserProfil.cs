namespace JobTaxiService.Dto
{
    public class UserProfil
    {
        public string   id_yandex           { get; set; }
        public string   login               { get; set; }
        public string   client_id           { get; set; }
        public string   display_name        { get; set; }
        public string   real_name           { get; set; }
        public string   first_name          { get; set; }
        public string   last_name           { get; set; }
        public string   sex                 { get; set; }
        public string   default_email       { get; set; }        
        public DateTime birthday            { get; set; }
        public string   default_avatar_id   { get; set; }
        public string   is_avatar_empty     { get; set; }
        public string   default_phone       { get; set; }        
    }
}
