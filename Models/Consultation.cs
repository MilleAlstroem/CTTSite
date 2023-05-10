using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CTTSite.Models
{
    public class Consultation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public TimeSpan StartTime { get; set; }        

        public TimeSpan EndTime { get; set; }

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
