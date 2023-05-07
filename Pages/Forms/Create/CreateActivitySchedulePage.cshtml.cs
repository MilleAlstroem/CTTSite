using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CTTSite.Models.Forms;

// Made by Christian

namespace CTTSite.Pages.Forms
{
    public class CreateActivitySchedulePageModel : PageModel
    {
        private IFormService _formService;

        [BindProperty]
        public FormActivitySchedule formActivitySchedule { get; set; }

        public CreateActivitySchedulePageModel(IFormService formService)
        {
            _formService = formService;
        }

        

        public void OnGet()
        {

        }
    }
}
