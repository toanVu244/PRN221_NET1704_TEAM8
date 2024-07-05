using JPOS.Model.Models;
using JPOS.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JPOS.Controller.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserServices _userServices;
        [BindProperty]
        public String UserName { get; set; }
        [BindProperty]
        public String Password { get; set; }

        public LoginModel(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public void OnGet()
        {

        }


        public void OnPost() 
        {
            var login  = _userServices.AuthenticateAsync(UserName, Password);
            if(login != null)
            {
                HttpContext.Session.SetString("UserName", UserName);
                /*HttpContext.Session.SetInt32("Role", login.G);*/
                Response.Redirect("/Home");

            }
        }
    }


}
