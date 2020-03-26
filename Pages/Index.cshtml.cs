using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GoogleAuther.Pages
{
    public class IndexModel : PageModel
    {
        public Claim GivenNameClaim { get; set; }
        public Claim LocaleClaim { get; set; }
        public Claim PictureUrlClaim { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {            
        }

        public void OnGet()
        {
            GivenNameClaim = HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.GivenName);
            LocaleClaim = HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == "urn:google:locale");
            PictureUrlClaim = HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == "urn:google:picture");
        }        
    }
}
