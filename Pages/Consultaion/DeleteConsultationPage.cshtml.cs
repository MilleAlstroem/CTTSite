using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Consultaion
{
    public class DeleteConsultationPageModel : PageModel
    {
        public IConsultationService IConsultationService;

        [BindProperty]
        public Models.Consultation Consultation { get; set; }

        public DeleteConsultationPageModel(IConsultationService iConsultationService)
        {
            IConsultationService = iConsultationService;
        }

        public async Task OnGetAsync(int ID)
        {
            Consultation = await IConsultationService.GetConsultationByIDAsync(ID);
        }

        public async Task<IActionResult> OnPost()
        {
            await IConsultationService.DeleteConsultation(Consultation);
            return RedirectToPage("GetAllConsultaionsPage");
        }
    }
}
