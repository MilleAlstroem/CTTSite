using CTTSite.Models;

namespace CTTSite.Services.Interface
{
    public interface IConsultationService
    {
        Task CreateConsultation(Consultation consultation);
        Task DeleteConsultation(int ID);
        Task UpdateConsultation(Consultation consultationN);
        Consultation GetConsultationByID(int ID);
        List<Consultation> GetAllConsultations();


    }
}
