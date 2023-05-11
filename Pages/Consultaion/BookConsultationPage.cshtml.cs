using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Consultation
{
    public class BookConsultationPageModel : PageModel
    {
        public IConsultationService IConsultationService;

        [BindProperty]
        public Models.Consultation Consultation { get; set; }

        public BookConsultationPageModel(IConsultationService iConsultationService)
        {
            IConsultationService = iConsultationService;
        }

        public void OnGet(int ID)
        {
            Consultation = IConsultationService.GetConsultationByID(ID);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await IConsultationService.SubmitConsultationByEmail(Consultation, Consultation.BookedEmail);
            return RedirectToPage("GetAllConsultaionsPage");
        }
    }
}
