using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CTTSite.Models
{
    public class Consultation
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }
        
        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        public int UserID { get; set; }
        public string BookedNamed { get; set; }
        public string TelefonNummer { get; set; }
        public string BookedEmail { get; set; }

        public Consultation(int iD, DateTime date, TimeSpan startTime, TimeSpan endTime, int userID, string bookedNamed, string telefonNummer, string bookedEmail)
        {
            ID = iD;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            UserID = userID;
            BookedNamed = bookedNamed;
            TelefonNummer = telefonNummer;
            BookedEmail = bookedEmail;
        }

        public Consultation()
        {
        }
    }
}
