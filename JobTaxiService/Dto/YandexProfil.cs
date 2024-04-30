namespace JobTaxiService.Dto
{
    public class YandexProfil
    {
        public string id { get; set; }
        public string login { get; set; }
        public string client_id { get; set; }
        public string display_name { get; set; }
        public string real_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string sex { get; set; }
        public string default_email { get; set; }
        public List<string> emails { get; set; }
        public string birthday { get; set; }
        public string default_avatar_id { get; set; }
        public string is_avatar_empty { get; set; }
        public DefaultPhone default_phone { get; set; }
        public string psuid { get; set; }
    }
}
