using CTTSite.Models;
using CTTSite.Services.DB;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;

namespace CTTSite.Services.NormalService
{
    public class ConsultationService : IConsultationService
    {
        public List<Consultation> ConsultationsList;
        //public DBServiceGeneric<Consultation> DBServiceGeneric;
        public JsonFileService<Consultation> JsonFileService;

        public ConsultationService(/*DBServiceGeneric<Consultation> dBServiceGeneric,*/ JsonFileService<Consultation> jsonFileService)
        {
            //DBServiceGeneric = dBServiceGeneric;
            JsonFileService = jsonFileService;
            ConsultationsList = GetAllConsultations();
        }

        public List<Consultation> GetAllConsultations()
        {
            return JsonFileService.GetJsonObjects().ToList();
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

        public void CreateConsultation(Consultation consultation)
        {
            int IDCount = 0;
            foreach(Consultation listConsultation in ConsultationsList)
            {
                if(IDCount < listConsultation.ID)
                {
                    IDCount = listConsultation.ID;
                }
            }
            consultation.ID = IDCount + 1;
            ConsultationsList.Add(consultation);
            //DBServiceGeneric.AddObjectAsync(consultation);
            JsonFileService.SaveJsonObjects(ConsultationsList);
        }

        public void DeleteConsultation(int ID)
        {
            Consultation consultationToBeDeleted = null; 
            if(GetConsultationByID(ID) != null)
            {
                ConsultationsList.Remove(GetConsultationByID(ID));
                JsonFileService.SaveJsonObjects(ConsultationsList);
            }
        }

        public Consultation UpdateConsultation(Consultation consultationN)
        {
            if (consultationN != null)
            {
                foreach (Consultation consultationO in ConsultationsList)
                {
                    if (consultationO.ID == consultationN.ID)
                    {
                        consultationO.StartDateTime = consultationN.StartDateTime;
                        consultationO.EndDateTime = consultationN.EndDateTime;
                        consultationO.UserID = consultationN.UserID;
                        consultationO.BookedNamed = consultationN.BookedNamed;
                        consultationO.TelefonNummer = consultationN.TelefonNummer;
                        consultationO.BookedEmail = consultationN.BookedEmail;
                    }
                    JsonFileService.SaveJsonObjects(ConsultationsList);
                }
            }
            return null;
        }
    }
}
