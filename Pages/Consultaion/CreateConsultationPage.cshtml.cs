using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Consultation
{
    public class CreateConsultationModel : PageModel
    {
        public IConsultationService IConsultationService;
        public IUserService IUserService;

        [BindProperty]
        public Models.Consultation Consultation { get; set; }

        public CreateConsultationModel(IConsultationService iConsultationService, IUserService iUserService)
        {
            IConsultationService = iConsultationService;
            IUserService = iUserService;
        }

        public void OnGet()
        {

        }

        public void OnPost() 
        {
            Consultation.UserID = 1; // i need the HTTP.Name thing to return me a id nr.
            IConsultationService.CreateConsultation(Consultation);
        }
    }
}
