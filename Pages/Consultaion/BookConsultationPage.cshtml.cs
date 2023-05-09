using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Consultation
{
    public class BookConsultationPageModel : PageModel
    {
        public IConsultationService IConsultationService;

        public BookConsultationPageModel(IConsultationService iConsultationService)
        {
            IConsultationService = iConsultationService;
        }

        public void OnGet()
        {
        }
    }
}
