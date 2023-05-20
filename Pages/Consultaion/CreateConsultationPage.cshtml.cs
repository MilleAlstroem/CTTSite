using CTTSite.Models;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace CTTSite.Pages.Consultation
{
    [Authorize(Roles = "admin")]
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
            Consultation.UserID = IUserService.GetUserIdByEmail(HttpContext.User.Identity.Name);
            Consultation.BookedNamed = "";
            Consultation.TelefonNummer = "";
            Consultation.BookedEmail = "";
            Consultation.Booked = false;
            await IConsultationService.CreateConsultation(Consultation);
            return RedirectToPage("GetAllConsultaionsPage");
        }
    }
}
