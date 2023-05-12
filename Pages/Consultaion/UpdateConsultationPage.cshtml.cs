using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Consultation
{
    public class UpdateConsultationPageModel : PageModel
    {
        public IConsultationService IConsultationService;

        [BindProperty]
        public Models.Consultation Consultation { get; set; }

        public UpdateConsultationPageModel(IConsultationService iConsultationService)
        {
            IConsultationService = iConsultationService;
        }

        public void OnGet(int id)
        {
            Consultation = IConsultationService.GetConsultationByID(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            Consultation.Date = Consultation.Date.Date;
            Consultation.StartTime = Consultation.StartTime;
            Consultation.EndTime = Consultation.EndTime;
            Consultation.UserID = 2; // Get the user ID from the appropriate source
            Consultation.BookedNamed = "";
            Consultation.TelefonNummer = "";
            Consultation.BookedEmail = "";
            await IConsultationService.UpdateConsultation(Consultation);
            return RedirectToPage("GetAllConsultaionsPage");
        }
    }
}
