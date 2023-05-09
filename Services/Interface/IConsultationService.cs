using CTTSite.Models;

namespace CTTSite.Services.Interface
{
    public interface IConsultationService
    {
        void CreateConsultation(Consultation consultation);
        void DeleteConsultation(int ID);
        Consultation UpdateConsultation(Consultation consultationN);
        Consultation GetConsultationByID(int ID);
        List<Consultation> GetAllConsultations();


    }
}
