using CTTSite.Models.Forms;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Forms
{
    public class UpdateSleepDiaryPageModel : PageModel
    {
        private IFormService _formService;

        [BindProperty]
        public FormSleepDiary formSleepDiary { get; set; }
        public string message { get; set; }

        public UpdateSleepDiaryPageModel(IFormService formService)
        {
            _formService = formService;
        }

        public void OnGet(int id)
        {
            if (_formService.GetFormSleepDiaryById(id) != null)
            {
                formSleepDiary = _formService.GetFormSleepDiaryById(id);
            }
            else
            {
                RedirectToPage("/Forms/FormsMenuPage");
            }
        }

        public IActionResult OnPostSubmitForm()
        {
            bool filledOut = false;

            foreach (var property in formSleepDiary.GetType().GetProperties())
            {
                if (property.GetValue(formSleepDiary) == "Please Fill Out Before Submission")
                {
                    filledOut = false;
                    message = "Please fill out the form before submission or save the form for later";
                    break;
                }
                else
                {
                    filledOut = true;
                }
            }

            if (filledOut)
            {
                _formService.UpdateFormSleepDiary(formSleepDiary);
                FormSleepDiary submitForm = _formService.GetFormSleepDiaryById(formSleepDiary.ID);

                _formService.SubmitFormSleepDiary(submitForm, submitForm.UserEmail);
                _formService.DeleteFormSleepDiary(submitForm.ID);
                return RedirectToPage("/Forms/FormsMenuPage");
            }
            else
            {
                _formService.UpdateFormSleepDiary(formSleepDiary);
                formSleepDiary = _formService.GetFormSleepDiaryById(formSleepDiary.ID);

                return Page();
            }
        }

        public IActionResult OnPostSaveForm()
        {
            _formService.UpdateFormSleepDiary(formSleepDiary);
            return RedirectToPage("/Forms/FormsMenuPage");
        }


    }
}
