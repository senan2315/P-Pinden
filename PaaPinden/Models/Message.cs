using PaaPinden.Data;

namespace PaaPinden.Models
{
    public class Message
    {
        public int MessageID { get; set; } //PK

        public string SenderID { get; set; } = null!; //FK (Who sent the message)
        public ApplicationUser Sender { get; set; } = null!;

        public string ReceiverID { get; set; } = null!;  //FK (Who received the message)
        public ApplicationUser Receiver { get; set; } = null!;

        public string Content { get; set; } = null!;
        public DateTime SentAt { get; set; }
    }
}
