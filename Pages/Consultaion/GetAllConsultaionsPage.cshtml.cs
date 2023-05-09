using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Consultation
{
    public class GetAllConsultaionsPageModel : PageModel
    {
        public IConsultationService IConsultationService;

        public List<Models.Consultation> ConsultationsList;

        public GetAllConsultaionsPageModel(IConsultationService consultationService)
        {
            IConsultationService = consultationService;
        }

        public void OnGet()
        {
            ConsultationsList = IConsultationService.GetAllConsultations();
        }
    }
}
