using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Consultaion
{
    public class DeleteConsultationPageModel : PageModel
    {
        private readonly IConsultationService _consultationService;

        [BindProperty]
        public Models.Consultation Consultation { get; set; }

        public DeleteConsultationPageModel(IConsultationService consultationService)
        {
            _consultationService = consultationService;
        }

        public async Task OnGetAsync(int ID)
        {
            Consultation = await _consultationService.GetConsultationByIDAsync(ID);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _consultationService.DeleteConsultation(Consultation);
            return RedirectToPage("GetAllConsultaionsPage");
        }
    }
}
