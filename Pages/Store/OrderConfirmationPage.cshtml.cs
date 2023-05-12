using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTTSite.Pages.Store
{
    public class OrderConfirmationPageModel : PageModel
    {
        public int OrderID { get; set; }

        public void OnGet(int ID)
        {
            OrderID = ID;
        }
    }
}
