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

        public IActionResult OnPostSave()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _formService.CreateFormActivityDiary(formActivityDiary);
            return RedirectToPage("/Forms/ActivityDiaryPage");
        }

        public IActionResult OnPostSubmit()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _formService.SaveFormUserDAO(HttpContext.User.Identity.Name, formActivityDiary);
            _formService.SubmitFormActivityDiary(formActivityDiary);           
            return RedirectToPage("/Forms/ActivityDiaryPage");
        }
    }
}
