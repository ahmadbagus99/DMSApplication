using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.LoginPage
{
    public class LoginModel : PageModel
    {
        public Credential Credential { get; set; }

        public void OnGet()
        {
        }
    }

    public class Credential
    {
        public int Id {  get; set; }
        public string Username { get; set; }   
        public string Password { get; set; }        

    }
}
