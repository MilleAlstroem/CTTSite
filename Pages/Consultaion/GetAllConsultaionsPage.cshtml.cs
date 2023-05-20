using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Consultation
{
    public class GetAllConsultaionsPageModel : PageModel
    {
        private readonly IConsultationService _consultationService;

        public List<Models.Consultation> ConsultationsList { get; set; }

        public GetAllConsultaionsPageModel(IConsultationService consultationService)
        {
            _consultationService = consultationService;
        }

        public async Task OnGetAsync()
        {
            ConsultationsList = await _consultationService.GetAllConsultationsAsync();
        }
    }
}
