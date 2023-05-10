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


        public string message { get; set; } 
        public UpdateActivityListPageModel(IFormService formService)
        {
            _formService = formService;
        }



        public void OnGet(int id)
        {
            if (_formService.GetFormActivityListById(id) != null)
            {
                formActivityList = _formService.GetFormActivityListById(id);
            }
            else
            {
                RedirectToPage("/Forms/FormsMenuPage");
            }
        }

        public IActionResult OnPostSubmitForm()
        {
            bool filledOut = false;

            foreach (var property in formActivityList.GetType().GetProperties())
            {
                if (property.GetValue(formActivityList) == "Please Fill Out Before Submission")
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
                _formService.UpdateFormActivityList(formActivityList);
                

                _formService.SubmitFormActivityList(formActivityList, formActivityList.UserEmail);
                _formService.DeleteFormActivityList(formActivityList);
                return RedirectToPage("/Forms/FormsMenuPage");
            }
            else
            {
                _formService.UpdateFormActivityList(formActivityList);
                formActivityList = _formService.GetFormActivityListById(formActivityList.ID);

                return Page();
            }
        }

        public IActionResult OnPostSaveForm()
        {
            _formService.UpdateFormActivityList(formActivityList);
            return RedirectToPage("/Forms/FormsMenuPage");
        }
    }
}
