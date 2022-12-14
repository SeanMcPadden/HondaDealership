using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HondaDealership.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            //Verify the Credential
            if (Credential.UserName == "admin" && Credential.Password == "password")
            {
                //Creatin the security Context
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin@mywebsite.com")
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Admin/InStockCarsAdmin");
            }

            return Page();
        }
    }

    public class Credential
        {
            [Required]
            [Display(Name = ("User Name"))]
            public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
            public string Password { get; set; }
        }

}
