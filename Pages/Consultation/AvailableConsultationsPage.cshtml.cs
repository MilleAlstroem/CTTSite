using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Consultation
{
    public class AvailableConsultationsPageModel : PageModel
    {
        private readonly IConsultationService _consultationService;

        public List<Models.Consultation> ConsultationsList { get; set; }

        public AvailableConsultationsPageModel(IConsultationService consultationService)
        {
            _consultationService = consultationService;
        }

        public async Task OnGetAsync()
        {
            //await _consultationService.DeleteExpiredUnbookedConsultationsAsync();
            ConsultationsList = await _consultationService.GetAvailableConsultationsAsync();
        }
    }
}
