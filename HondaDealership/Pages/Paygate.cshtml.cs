using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stripe;
using Stripe.BillingPortal;
using Stripe.Checkout;
using System.Collections.Generic;

namespace HondaDealership.Pages
{
    public class PaygateModel : PageModel
    {

    }

    //        public void OnGet()
    //        {
    //            var domain = "http://localhost:4242";
    //            var options = new Stripe.BillingPortal.SessionCreateOptions
    //            {
    //                LineItems = new List<SessionLineItemOptions>
    //                {
    //                  new SessionLineItemOptions
    //                  {
    //                    // Provide the exact Price ID (for example, pr_1234) of the product you want to sell
    //                    Price = "{{PRICE_ID}}",
    //                    Quantity = 1,
    //                  },
    //                },
    //                //Mode = "payment",
    //                SuccessUrl = domain + "/success.html",
    //                CancelUrl = domain + "/cancel.html",
    //            };
    //            var service = new SessionService();
    //            Session session = service.Create(options);

    //            Response.Headers.Add("Location", session.Url);
    //            return new StatusCodeResult(303);
    //        }
    //    }
    //}
    //}






    //using System.Collections.Generic;
    //using Microsoft.AspNetCore;
    //using Microsoft.AspNetCore.Builder;
    //using Microsoft.AspNetCore.Hosting;
    //using Microsoft.AspNetCore.Mvc;
    //using Microsoft.Extensions.DependencyInjection;
    //using Microsoft.Extensions.Hosting;
    //using Stripe;
    //using Stripe.Checkout;

    //public class StripeOptions
    //{
    //    public string option { get; set; }
    /// <summary>
    /// }
    /// </summary>

    //namespace server.Controllers
    //{
    //    public class Program
    //    {
    //        public static void Main(string[] args)
    //        {
    //            WebHost.CreateDefaultBuilder(args)
    //              .UseUrls("http://0.0.0.0:4242")
    //              .UseWebRoot("public")
    //              .UseStartup<Startup>()
    //              .Build()
    //              .Run();
    //        }
    //    }


    //[Route("create-checkout-session")]
    //[ApiController]
    /*public class CheckoutApi
    {
        [HttpPost]
        public ActionResult Create()
        {
            var domain = "http://localhost:4242";
            var options = new Stripe.BillingPortal.SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                    {
                      new SessionLineItemOptions
                      {
                        // Provide the exact Price ID (for example, pr_1234) of the product you want to sell
                        Price = "{{PRICE_ID}}",
                        Quantity = 1,
                      },
                    },
                Mode = "payment",
                SuccessUrl = domain + "/success.html",
                CancelUrl = domain + "/cancel.html",
            };
            var service = new Stripe.BillingPortal.SessionService();
            Stripe.BillingPortal.Session session = service.Create(options);

            //Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        } 
    } */
}