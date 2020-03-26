using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoogleAuther.Pages.Account
{
    public class LoginModel : PageModel
    {
        public string ReturnUrl { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

        }

        public async Task OnGetAsync(string returnUrl = null)
        {           
            returnUrl = returnUrl ?? Url.Content("~/");
            ReturnUrl = returnUrl;
            await HttpContext.SignOutAsync();            
            ReturnUrl = returnUrl;
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ReturnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                var properties = new AuthenticationProperties
                {
                    AllowRefresh = false,
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddSeconds(10)
                };
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,Input.Email),
                    new Claim(ClaimTypes.Name,Input.Email)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal, properties);
                return LocalRedirect(ReturnUrl);
            }
            return Page();
        }
    }
}