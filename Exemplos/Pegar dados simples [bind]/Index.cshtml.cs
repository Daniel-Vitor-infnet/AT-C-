using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AT.Pages.Home
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Nome { get; set; }

        [BindProperty]
        public int Idade { get; set; }

        public void OnGet() { }

        public void OnPost() { }
    }
}
