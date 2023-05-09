using CTTSite.Models;

namespace CTTSite.MockData
{
    public class MockDataConsultation
    {

        public static List<Consultation> consultationsList = new List<Consultation>()
        {
            new Consultation(1, DateTime.Now, DateTime.Now.AddHours(1), 2, "Mads Ludvigsen","61675837", "Hifnh@live.dk"),
            new Consultation(2, DateTime.Now.AddHours(1), DateTime.Now.AddHours(2), 2, "Mads EgeLund","61675837", "Hifnh@live.dk"),
            new Consultation(3, DateTime.Now.AddHours(2), DateTime.Now.AddHours(3), 2, "The Queen","61675837", "Hifnh@live.dk"),
            new Consultation(4, DateTime.Now.AddHours(3), DateTime.Now.AddHours(4), 2, "Jennie","61675837", "Hifnh@live.dk"),
        };


        public static List<Consultation> GetAllConsultations()
        {
            return consultationsList;
        }

    }
}
