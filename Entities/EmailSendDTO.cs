namespace Covid19ProjectAPI.Entities
{
    public class EmailSendDTO
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public EmailSendDTO(string To,string subject,string body)
        {
            this.To = To;
            this.Subject = subject; 
            this.Body = body;
        }   
    }
}
