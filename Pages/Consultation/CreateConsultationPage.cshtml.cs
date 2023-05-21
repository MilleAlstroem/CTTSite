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
        private readonly IConsultationService _consultationService;
        private readonly IUserService _userService;

        public string Message { get; set; }
        public string MessageColor { get; set; }
        [BindProperty]
        public Models.Consultation Consultation { get; set; } = new Models.Consultation();

        public CreateConsultationModel(IConsultationService consultationService, IUserService userService)
        {
            _consultationService = consultationService;
            _userService = userService;
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
            //if ( await _consultationService.IsConsultationDateAvailableAsync(Consultation) == false )
            //{
            //    Message = "New consultations must be set to be a time after the the present time";
            //    MessageColor = "red";
            //}
            //if( await _consultationService.IsConsultationTimeSlotAvailableAsync(Consultation) == true)
            //{
            //    return RedirectToPage("GetAllConsultaionsPage");
            //}
            //else
            //{
            //    Message = "This time slot is not available";
            //    MessageColor = "red";
            //    return Page();
            //}
            await _consultationService.CreateConsultationAsync(Consultation);
            return RedirectToPage("GetAllConsultaionsPage");
        }

        
    }
}
