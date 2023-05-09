using System.Data;

namespace CTTSite.Models
{
    public class Consultation
    {
        public int ID { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int UserID { get; set; }
        public string BookedNamed { get; set; }
        public string TelefonNummer { get; set; }
        public string BookedEmail { get; set; }

        public Consultation(int iD, DateTime startDataTime, DateTime endDateTime, int userID, string bookedNamed, string telefonNummer, string bookedEmail)
        {
            ID = iD;
            StartDateTime = startDataTime;
            EndDateTime = endDateTime;
            UserID = userID;
            BookedNamed = bookedNamed;
            TelefonNummer = telefonNummer;
            BookedEmail = bookedEmail;
        }
    }
}
