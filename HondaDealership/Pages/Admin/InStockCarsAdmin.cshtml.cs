using HondaDealership.Data_Access;
using HondaDealership.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace HondaDealership.Pages.Admin
{
    [Authorize]
    public class InStockCarsAdminModel : PageModel
    {
            public List<Car> listCars = new List<Car>();

            private readonly ApplicationDBContext _context;

            public InStockCarsAdminModel(ApplicationDBContext context)
            {
                _context = context;
            }


            public void OnGet()
            {
                listCars = _context.Car.ToList();

            }
        }
}
