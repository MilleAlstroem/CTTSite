using CTTSite.Models.Forms;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Forms
{
    public class UpdateActivitySchedulePageModel : PageModel
    {
        private IFormService _formService;

        [BindProperty]
        public FormActivitySchedule formActivitySchedule { get; set; }

        public UpdateActivitySchedulePageModel(IFormService formService)
        {
            _formService = formService;
        }



        public void OnGet()
        {

        }
    }
}
