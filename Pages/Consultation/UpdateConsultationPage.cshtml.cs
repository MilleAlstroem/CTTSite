using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Consultation
{
    public class UpdateConsultationPageModel : PageModel
    {
        private readonly IConsultationService _consultationService;

        [BindProperty]
        public Models.Consultation Consultation { get; set; }
        public int UserID { get; set; }

        public UpdateConsultationPageModel(IConsultationService iConsultationService)
        {
            _consultationService = iConsultationService;
        }

        public async Task OnGetAsync(int id)
        {
            Consultation = await _consultationService.GetConsultationByIDAsync(id);
            UserID = Consultation.UserID;
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
            Consultation.UserID = UserID;
            Consultation.BookedNamed = "";
            Consultation.TelefonNummer = "";
            Consultation.BookedEmail = "";
            await _consultationService.UpdateConsultation(Consultation);
            return RedirectToPage("GetAllConsultaionsPage");
        }
    }
}
