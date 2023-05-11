using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Consultaion
{
    public class DeleteConsultationPageModel : PageModel
    {
        public IConsultationService IConsultationService;

        [BindProperty]
        public Models.Consultation Consultation { get; set; }

        public DeleteConsultationPageModel(IConsultationService iConsultationService)
        {
            IConsultationService = iConsultationService;
        }

        public void OnGet(int ID)
        {
            Consultation = IConsultationService.GetConsultationByID(ID);
        }

        public IActionResult OnPost()
        {
            IConsultationService.DeleteConsultation(Consultation.ID);
            return RedirectToPage("/Index");
        }
    }
}
