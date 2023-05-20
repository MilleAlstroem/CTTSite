using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Consultaion
{
    public class AvailableConsultationsPageModel : PageModel
    {
        public IConsultationService IConsultationService;

        public List<Models.Consultation> ConsultationsList { get; set; }

        public AvailableConsultationsPageModel(IConsultationService iConsultationService )
        {
            IConsultationService = iConsultationService;
        }
        public async Task OnGetAsync()
        {
            ConsultationsList = await IConsultationService.GetAllConsultationsAsync();
        }
    }
}
