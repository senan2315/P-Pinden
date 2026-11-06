namespace PaaPinden.Models
{
    public class Message
    {
        public int MessageID { get; set; } //PK
        public int UserID { get; set; } //FK (Who sent the message)
        public string Content { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime SentAt { get; set; }
    }
}
