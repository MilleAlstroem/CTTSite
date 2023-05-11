using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTTSite.Models
{
    public class ShippingInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        public string County { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }


        public ShippingInfo(int userID, string address, string city, string postCode, string county, string phoneNumber, string firstName, string lastName, DateTime submissionDate)
        {
            UserID = userID;
            Address = address;
            City = city;
            PostCode = postCode;
            County = county;
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            SubmissionDate = submissionDate;
        }

        public ShippingInfo()
        {
            
        }

    }
}
