using CTTSite.Models;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace CTTSite.Pages.Consultation
{
    public class CreateConsultationModel : PageModel
    {
        public IConsultationService _consultationService;
        public readonly IUserService _userService;

        [BindProperty]
        public Models.Consultation Consultation { get; set; } = new Models.Consultation();

        public CreateConsultationModel(IConsultationService consultationService, IUserService userService)
        {
            _consultationService = consultationService;
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Consultation.Date = Consultation.Date.Date;
            Consultation.StartTime = Consultation.StartTime;
            Consultation.EndTime = Consultation.EndTime;
            Consultation.UserID = 2; // Get the user ID from the appropriate source
            Consultation.BookedNamed = " ";
            Consultation.TelefonNummer = " ";
            Consultation.BookedEmail = " ";
            _consultationService.CreateConsultation(Consultation);
            return RedirectToPage("GetAllConsultaionsPage");
        }
    }
}
