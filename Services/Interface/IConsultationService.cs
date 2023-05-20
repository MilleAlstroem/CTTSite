using CTTSite.Models;

namespace CTTSite.Services.Interface
{
    public interface IConsultationService
    {
        Task CreateConsultation(Consultation consultation);
        Task DeleteConsultation(Consultation consultation);
        Task UpdateConsultation(Consultation consultationN);
        Task SubmitConsultationByEmail(Consultation consultation, string email);
        Task<Consultation> GetConsultationByIDAsync(int ID);
        Task<List<Consultation>> GetAllConsultationsAsync();


    }
}
