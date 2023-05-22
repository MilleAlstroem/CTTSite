﻿using CTTSite.Models;

namespace CTTSite.Services.Interface
{
    public interface IConsultationService
    {
        Task CreateConsultationAsync(Consultation consultation);
        Task DeleteConsultationAsync(Consultation consultation);
        Task UpdateConsultationAsync(Consultation consultationN);
        Task SubmitConsultationByEmailAsync(Consultation consultation, string email);
        Task<Consultation> GetConsultationByIDAsync(int ID);
        Task<List<Consultation>> GetAllConsultationsAsync();
        Task<List<Consultation>> GetAvailableConsultationsAsync();
        Task DeleteExpiredUnbookedConsultationsAsync();
        Task<bool> IsDateWithInPresentDateAsync(Consultation consultation);
        Task<bool> IsTimeSlotAvailableInDataBaseAsync(Consultation consultation);
        Task<bool> IsTimeSlotCorrectEnteredAsync(Consultation consultation);
        Task<bool> IsTimeSlotBeforeDateNowAsync(Consultation consultation);


    }
}
