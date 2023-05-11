using CTTSite.Models;
using CTTSite.Models.Forms;
using CTTSite.Services.DB;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;

namespace CTTSite.Services.NormalService
{
    public class ConsultationService : IConsultationService
    {
        public IEmailService IEmailService;
        public List<Consultation> ConsultationsList;
        public DBServiceGeneric<Consultation> DBServiceGeneric;
        public JsonFileService<Consultation> JsonFileService;

        public ConsultationService(DBServiceGeneric<Consultation> dBServiceGeneric, JsonFileService<Consultation> jsonFileService, IEmailService iEmailService)
        {
            DBServiceGeneric = dBServiceGeneric;
            JsonFileService = jsonFileService;
            ConsultationsList = GetAllConsultations();
            IEmailService = iEmailService;
        }

        public List<Consultation> GetAllConsultations()
        {
            return DBServiceGeneric.GetObjectsAsync().Result.ToList();
            //return JsonFileService.GetJsonObjects().ToList();
            //return MockData.MockDataConsultation.GetAllConsultations();
        }

        public Consultation GetConsultationByID(int ID)
        {
            foreach (Consultation consultation in ConsultationsList)
            {
                if (consultation.ID == ID)
                {
                    return consultation;
                }
            }
            return null;
        }

        public async Task CreateConsultation(Consultation consultation)
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
            await DBServiceGeneric.AddObjectAsync(consultation);
            //JsonFileService.SaveJsonObjects(ConsultationsList);
        }

        public async Task DeleteConsultation(Consultation consultation)
        {
            Consultation consultationToBeDeleted = null; 
            if(consultation != null)
            {
                ConsultationsList.Remove(consultation);
                //JsonFileService.SaveJsonObjects(ConsultationsList);
                await DBServiceGeneric.DeleteObjectAsync(consultation);
            }
        }

        public async Task UpdateConsultation(Consultation consultationN)
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
                //JsonFileService.SaveJsonObjects(ConsultationsList);
                await DBServiceGeneric.UpdateObjectAsync(consultationN);
            }
        }

        public async Task SubmitConsultationByEmail(Consultation consultation, string email)
        {
            IEmailService.SendEmail(new Email(consultation.ToString(), "Booking of Consultation: " + email, email));
            IEmailService.SendEmail(new Email(consultation.ToString(), "Booking of Consultation: " + email, "chilterntalkingtherapies@gmail.com"));
            await DBServiceGeneric.DeleteObjectAsync(consultation);
        }
    }
}
