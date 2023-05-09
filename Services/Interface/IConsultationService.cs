using CTTSite.Models;

namespace CTTSite.Services.Interface
{
    public interface IConsultationService
    {
        void CreateConsultation(Consultation consultation);
        void DeleteConsultation();
        void UpdateConsultation();
        void GetConsultation();
        List<Consultation> GetAllConsultations();


    }
}
