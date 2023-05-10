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
        public string message { get; set; }

        public UpdateHotCrossBunPageModel(IFormService formService)
        {
            _formService = formService;
        }



        public void OnGet(int id)
        {
            if (_formService.GetFormHotCrossBunById(id) != null)
            {
                formHotCrossBun = _formService.GetFormHotCrossBunById(id);
            }
            else
            {
                RedirectToPage("/Forms/FormsMenuPage");
            }
        }

        public IActionResult OnPostSubmitForm()
        {
            bool filledOut = false;

            foreach (var property in formHotCrossBun.GetType().GetProperties())
            {
                if (property.GetValue(formHotCrossBun) == "Please Fill Out Before Submission")
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
                _formService.UpdateFormHotCrossBun(formHotCrossBun);
                FormHotCrossBun submitForm = _formService.GetFormHotCrossBunById(formHotCrossBun.ID);

                _formService.SubmitFormHotCrossBun(submitForm, submitForm.UserEmail);
                _formService.DeleteFormHotCrossBun(submitForm.ID);
                return RedirectToPage("/Forms/FormsMenuPage");
            }
            else
            {
                _formService.UpdateFormHotCrossBun(formHotCrossBun);
                formHotCrossBun = _formService.GetFormHotCrossBunById(formHotCrossBun.ID);

                return Page();
            }
        }

        public IActionResult OnPostSaveForm()
        {
            _formService.UpdateFormHotCrossBun(formHotCrossBun);
            return RedirectToPage("/Forms/FormsMenuPage");
        }
    }
}
