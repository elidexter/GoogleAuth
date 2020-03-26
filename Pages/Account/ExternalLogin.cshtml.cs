using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoogleAuther.Pages.Account
{
    public class ExternalLoginModel : PageModel
    {
        public string ReturnURL { get; set; }
        public IActionResult OnGetAsync()
        {
            return RedirectToPage("./Login");
        }
        public IActionResult OnPost(string provider, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ReturnURL = returnUrl;
            string redirectUrl = Url.Action("GoogleResponse", "Account");
            //var redirectUrl = Url.Page("./Login", pageHandler: "Callback", values: new { returnUrl });
            var authProperties = new AuthenticationProperties
            {
                RedirectUri = returnUrl
            };
            return new ChallengeResult("Google", authProperties);
        }
        //public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        //{
        //    return LocalRedirect(ReturnURL);
        //}
    }
}