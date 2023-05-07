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
        public List<Form> forms { get; set; }

        public FormsMenuPageModel(IFormService formService)
        {
            _formService = formService;
        }

        public void OnGet()
        {
            if(_formService.GetForms(HttpContext.User.Identity.Name) != null)
            {
                forms = _formService.GetForms(HttpContext.User.Identity.Name);
            }
            else
            {
                forms = null; 
            }
        }
    }
}
