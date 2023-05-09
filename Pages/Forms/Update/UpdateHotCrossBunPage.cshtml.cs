using CTTSite.Models.Forms;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Forms
{
    public class UpdateHotCrossBunPageModel : PageModel
    {
        private IFormService _formService;

        [BindProperty]
        public FormHotCrossBun formHotCrossBun { get; set; }

        public UpdateHotCrossBunPageModel(IFormService formService)
        {
            _formService = formService;
        }



        public void OnGet()
        {

        }
    }
}
