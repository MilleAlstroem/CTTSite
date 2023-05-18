using CTTSite.Models;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Threading.Tasks;

namespace CTTSite.Pages.Consultation
{
    [Authorize(Roles = "admin")]
    public class CreateConsultationModel : PageModel
    {
        private readonly IConsultationService _consultationService;
        private readonly IUserService _userService;

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

        public async Task<IActionResult> OnPostAsync()
        {
            Consultation.Date = Consultation.Date.Date;
            Consultation.StartTime = Consultation.StartTime;
            Consultation.EndTime = Consultation.EndTime;
            Consultation.UserID = _userService.GetUserIdByEmail(HttpContext.User.Identity.Name);
            Consultation.BookedNamed = "";
            Consultation.TelefonNummer = "";
            Consultation.BookedEmail = "";
            Consultation.Booked = false;
            await _consultationService.CreateConsultation(Consultation);
            return RedirectToPage("GetAllConsultaionsPage");
        }
    }
}