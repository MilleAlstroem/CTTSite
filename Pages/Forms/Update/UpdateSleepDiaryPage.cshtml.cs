using CTTSite.Models.Forms;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Forms
{
    public class UpdateSleepDiaryPageModel : PageModel
    {
        private IFormService _formService;

        [BindProperty]
        public FormSleepDiary formSleepDiary { get; set; }

        public UpdateSleepDiaryPageModel(IFormService formService)
        {
            _formService = formService;
        }

        public void OnGet()
        {

        }

        
    }
}
