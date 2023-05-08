using CTTSite.Models.Forms;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Forms
{
    public class UpdateActivityListPageModel : PageModel
    {
        private IFormService _formService;

        [BindProperty]
        public FormActivityList formActivityList { get; set; }

        public UpdateActivityListPageModel(IFormService formService)
        {
            _formService = formService;
        }



        public void OnGet(int id)
        {
            _formService.GetFormActivityList(id);
        }
    }
}
