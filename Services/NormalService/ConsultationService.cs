using CTTSite.Models;
using CTTSite.Models.Forms;
using CTTSite.Services.DB;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;

namespace CTTSite.Services.NormalService
{
    public class ConsultationService : IConsultationService
    {
        private readonly IEmailService _emailService;
        private readonly DBServiceGeneric<Consultation> _dbServiceGeneric;
        private readonly JsonFileService<Consultation> _jsonFileService;
        public List<Consultation> ConsultationsList;

        public ConsultationService(DBServiceGeneric<Consultation> dbServiceGeneric, JsonFileService<Consultation> jsonFileService, IEmailService emailService)
        {
            _dbServiceGeneric = dbServiceGeneric;
            _jsonFileService = jsonFileService;
            _emailService = emailService;
            ConsultationsList = GetAllConsultationsAsync().Result;
        }

        public async Task<List<Consultation>> GetAllConsultationsAsync()
        {
            return (await _dbServiceGeneric.GetObjectsAsync()).ToList();
            //return JsonFileService.GetJsonObjects().ToList();
            //return MockData.MockDataConsultation.GetAllConsultations();
        }

        public async Task<List<Consultation>> GetAvailableConsultationsAsync()
        {
            await DeleteExpiredUnbookedConsultationsAsync();
            List<Consultation> allConsultations = await GetAllConsultationsAsync();
            return allConsultations.Where(c => !c.Booked).ToList();
        }

        public async Task<Consultation> GetConsultationByIDAsync(int ID)
        {
            //foreach (Consultation consultation in ConsultationsList)
            //{
            //    if (consultation.ID == ID)
            //    {
            //        return consultation;
            //    }
            //}
            return await _dbServiceGeneric.GetObjectByIdAsync(ID);
        }

        public async Task CreateConsultationAsync(Consultation consultation)
        {
            //int IDCount = 0;
            //foreach(Consultation listConsultation in ConsultationsList)
            //{
            //    if(IDCount < listConsultation.ID)
            //    {
            //        IDCount = listConsultation.ID;
            //    }
            //}
            //consultation.ID = IDCount + 1;
            consultation.Date = consultation.Date.Date;
            ConsultationsList.Add(consultation);
            await _dbServiceGeneric.AddObjectAsync(consultation);
            //_jsonFileService.SaveJsonObjects(ConsultationsList);
        }

        public async Task DeleteConsultationAsync(Consultation consultation)
        {
            Consultation consultationToBeDeleted = null; 
            if(consultation != null)
            {
                ConsultationsList.Remove(consultation);
                //_ssonFileService.SaveJsonObjects(ConsultationsList);
                await _dbServiceGeneric.DeleteObjectAsync(consultation);
            }
        }

        public async Task UpdateConsultationAsync(Consultation consultationN)
        {
            if (consultationN != null)
            {
                foreach (Consultation consultationO in ConsultationsList)
                {
                    if (consultationO.ID == consultationN.ID)
                    {
                        consultationO.Date = consultationN.Date;
                        consultationO.StartTime = consultationN.StartTime;
                        consultationO.EndTime = consultationN.EndTime;
                        consultationO.UserID = consultationN.UserID;
                        consultationO.BookedNamed = consultationN.BookedNamed;
                        consultationO.TelefonNummer = consultationN.TelefonNummer;
                        consultationO.BookedEmail = consultationN.BookedEmail;
                    }                    
                }
                //_jsonFileService.SaveJsonObjects(ConsultationsList);
                await _dbServiceGeneric.UpdateObjectAsync(consultationN);
            }
        }

        public async Task SubmitConsultationByEmailAsync(Consultation consultation, string email)
        {
            Consultation consultationToBeUpdated = await GetConsultationByIDAsync(consultation.ID);

            if (consultationToBeUpdated != null)
            {
                consultationToBeUpdated.BookedNamed = consultation.BookedNamed;
                consultationToBeUpdated.TelefonNummer = consultation.TelefonNummer;
                consultationToBeUpdated.BookedEmail = consultation.BookedEmail;
                consultationToBeUpdated.Booked = true;

                _emailService.SendEmail(new Email(consultation.ToString(), "Booking of Consultation: " + email, email));
                _emailService.SendEmail(new Email(consultation.ToString(), "Booking of Consultation: " + email, "chilterntalkingtherapies@gmail.com"));

                await _dbServiceGeneric.UpdateObjectAsync(consultationToBeUpdated);
            }
        }

        public async Task DeleteExpiredUnbookedConsultationsAsync()
        {
            List<Consultation> allConsultations = await GetAllConsultationsAsync();

            List<Consultation> expiredUnbookedConsultations = allConsultations
                .Where(c => !c.Booked && c.Date < DateTime.Now)
                .ToList();

            foreach (Consultation consultation in expiredUnbookedConsultations)
            {
                allConsultations.Remove(consultation);
                await _dbServiceGeneric.DeleteObjectAsync(consultation);
            }
        }

        public async Task<bool> IsConsultationTimeSlotAvailable(Consultation consultation)
        {
            if (consultation != null)
            {
                List<Consultation> allConsultations = await GetAllConsultationsAsync();

                bool isAvailable = allConsultations.Any(c =>
                    !c.Booked &&
                    c.Date == consultation.Date &&
                    (c.EndTime > consultation.StartTime && c.StartTime < consultation.EndTime) &&
                    c.Date >= DateTime.Now && c.EndTime > DateTime.Now.TimeOfDay);

                return isAvailable;
            }

            return false;
        }

    }
}
