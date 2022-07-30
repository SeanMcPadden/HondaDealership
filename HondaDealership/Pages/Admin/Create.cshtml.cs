using HondaDealership.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System;

namespace HondaDealership.Pages.Admin
{
    [Authorize]
    public class CreateModel : PageModel
    {
        public Car car = new Car();
        public string errorMessage = "";
        public string successMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            car.Make = Request.Form["Make"];
            car.CarModel = Request.Form["CarModel"];
            car.Year = Convert.ToInt32(Request.Form["Year"]);
            car.Colour = Request.Form["Colour"];
            car.Registration = Request.Form["Registration"];
            car.Price = Convert.ToInt32(Request.Form["Price"]);

            if (car.Make.Length == 0 || car.CarModel.Length == 0 ||
                car.Year <= 0 || car.Colour.Length == 0 ||
                car.Registration.Length == 0 || car.Price <= 0)
            {
                errorMessage = "All the fields are required";
                return;
            }

            //save the new car into the database
            try
            {
                string connectionString = "Server=(localdb)\\MSSQLLocalDB; database=HondaDealership;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Car" +
                                 "(Make, CarModel, Year, Colour, Registration, Price) VALUES " +
                                 "(@Make, @CarModel, @Year, @Colour, @Registration, @Price);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Make", car.Make);
                        command.Parameters.AddWithValue("@CarModel", car.CarModel);
                        command.Parameters.AddWithValue("@Year", car.Year);
                        command.Parameters.AddWithValue("@Colour", car.Colour);
                        command.Parameters.AddWithValue("@Registration", car.Registration);
                        command.Parameters.AddWithValue("@Price", car.Price);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }




            car.Make = ""; car.CarModel = ""; car.Year = 0;
            car.Colour = ""; car.Registration = ""; car.Price = 0;
            successMessage = "New car added correctly";

            Response.Redirect("/Admin/InStockCarsAdmin");

        }
    }
}
