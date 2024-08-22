namespace JobTaxiService.Dto
{
    public class Mail
    {
        public string EmailFrom     { get; set; }
        public string EmailTo       { get; set; } = string.Empty;
        public string EmailSubject  { get; set; } 
        public string EmailBody     { get; set; } = string.Empty;

    }
}
