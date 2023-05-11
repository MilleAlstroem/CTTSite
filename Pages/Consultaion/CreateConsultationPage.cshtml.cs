using CTTSite.Models;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace CTTSite.Pages.Consultation
{
    public class CreateConsultationModel : PageModel
    {
        public IConsultationService IConsultationService;
        public IUserService IUserService;

        [BindProperty]
        public Models.Consultation Consultation { get; set; } = new Models.Consultation();

        public CreateConsultationModel(IConsultationService consultationService, IUserService userService)
        {
            IConsultationService = consultationService;
            IUserService = userService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Consultation.Date = Consultation.Date.Date;
            Consultation.StartTime = Consultation.StartTime;
            Consultation.EndTime = Consultation.EndTime;
            Consultation.UserID = 2; // Get the user ID from the appropriate source
            Consultation.BookedNamed = "";
            Consultation.TelefonNummer = "";
            Consultation.BookedEmail = "";
            await IConsultationService.CreateConsultation(Consultation);
            return RedirectToPage("GetAllConsultaionsPage");
        }
    }
}
