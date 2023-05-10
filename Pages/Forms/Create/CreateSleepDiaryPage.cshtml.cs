using CTTSite.Models.Forms;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

// Made by Christian

namespace CTTSite.Pages.Forms
{
    public class CreateSleepDiaryPageModel : PageModel
    {
        private IFormService _formService;

        [BindProperty]
        public FormSleepDiary formSleepDiary { get; set; }

        public CreateSleepDiaryPageModel(IFormService formService)
        {
            _formService = formService;
        }

        public void OnGet()
        {

        }

        
    }
}
