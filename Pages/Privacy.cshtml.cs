using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GoogleAuther.Pages
{
    [Authorize]
    public class PrivacyModel : PageModel
    {       
        public PrivacyModel()   
        {         
        }

        public void OnGet()
        {
            
        }
    }
}
