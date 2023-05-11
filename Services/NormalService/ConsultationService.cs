using CTTSite.Models;
using CTTSite.Services.DB;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;

namespace CTTSite.Services.NormalService
{
    public class ConsultationService : IConsultationService
    {
        public List<Consultation> ConsultationsList;
        public DBServiceGeneric<Consultation> DBServiceGeneric;
        public JsonFileService<Consultation> JsonFileService;

        public ConsultationService(DBServiceGeneric<Consultation> dBServiceGeneric, JsonFileService<Consultation> jsonFileService)
        {
            DBServiceGeneric = dBServiceGeneric;
            JsonFileService = jsonFileService;
            ConsultationsList = GetAllConsultations();
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

        public async Task DeleteConsultation(int ID)
        {
            Consultation consultationToBeDeleted = null; 
            if(GetConsultationByID(ID) != null)
            {
                ConsultationsList.Remove(GetConsultationByID(ID));
                //JsonFileService.SaveJsonObjects(ConsultationsList);
                await DBServiceGeneric.DeleteObjectAsync(GetConsultationByID(ID));
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
                JsonFileService.SaveJsonObjects(ConsultationsList);
                await DBServiceGeneric.UpdateObjectAsync(consultationN);
            }
        }
    }
}
