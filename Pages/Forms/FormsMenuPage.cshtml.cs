using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CTTSite.Models.Forms;
using CTTSite.Services.Interface;

// Made by Christian

namespace CTTSite.Pages.Forms
{
    public class FormsMenuPageModel : PageModel
    {
        private IFormService _formService;
        

        public FormsMenuPageModel(IFormService formService)
        {
            _formService = formService;
        }

        public void OnGet()
        {
            
        }
    }
}
