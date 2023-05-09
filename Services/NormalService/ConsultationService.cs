using CTTSite.Models;
using CTTSite.Services.DB;
using CTTSite.Services.Interface;

namespace CTTSite.Services.NormalService
{
    public class ConsultationService : IConsultationService
    {
        public List<Consultation> Consultations;
        public DBServiceGeneric<Consultation> DBServiceGeneric;

        public void CreateConsultation(Consultation consultation)
        {
            
        }

        public void DeleteConsultation()
        {
            throw new NotImplementedException();
        }

        public List<Consultation> GetAllConsultations()
        {
            throw new NotImplementedException();
        }

        public void GetConsultation()
        {
            throw new NotImplementedException();
        }

        public void UpdateConsultation()
        {
            throw new NotImplementedException();
        }
    }
}
