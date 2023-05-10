using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CTTSite.Models.Forms;

// Made by Christian

namespace CTTSite.Pages.Forms
{
    public class UpdateActivityDiaryPageModel : PageModel
    {
        private IFormService _formService;
        public UpdateActivityDiaryPageModel(IFormService formService)
        {
            _formService = formService;
        }

        public FormActivityDiary formActivityDiary { get; set; }

        public void OnGet(int id)
        {
           formActivityDiary = _formService.GetFormActivityDiaryById(id);
        }
    }
}
