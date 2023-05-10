using CTTSite.Models.Forms;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Made by Christian

namespace CTTSite.Pages.Forms
{
    public class CreateActivityDiaryPageModel : PageModel
    {
        private IFormService _formService;

        [BindProperty]
        public FormActivityDiary formActivityDiary { get; set; }

        public CreateActivityDiaryPageModel(IFormService formService)
        {
            _formService = formService;
        }
       
        

        public void OnGet()
        {
            
        }

        

        
    }
}
