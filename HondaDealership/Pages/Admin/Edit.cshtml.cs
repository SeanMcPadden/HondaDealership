using HondaDealership.Data_Access;
using HondaDealership.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HondaDealership.Pages.Admin
{
    [Authorize]
    public class EditModel : PageModel
    {
       /* public List<Car> listCars = new List<Car>();

        private readonly ApplicationDBContext _context;

        public EditModel(ApplicationDBContext context)
        {
            _context = context;
        }
       */

        public Car car = new Car();
        public string errorMessage = "";
        public string successMessage = "";
        public string Id;

        public void OnGet()
        {
            
            Id = Request.Query["Id"];
            string testing = Id;

            //listCars = _context.listCars.ToList();

            try
            {
                string connectionString = "Server=(localdb)\\MSSQLLocalDB; database=HondaDealership;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Car WHERE Id=@Id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", Id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                car.Id = reader.GetInt32(0);
                                car.Make = reader.GetString(1);
                                car.CarModel = reader.GetString(2);
                                car.Year = reader.GetInt32(3);
                                car.Colour = reader.GetString(4);
                                car.Registration =  reader.GetString(5);
                                car.Price = reader.GetDecimal(6);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public void OnPost()
        {
            car.Make = Request.Form["Make"];
            car.CarModel = Request.Form["CarModel"];
            car.Year = Convert.ToInt32(Request.Form["Year"]);
            car.Colour = Request.Form["Colour"];
            car.Registration = Request.Form["Registration"];
            car.Price = Convert.ToDecimal(Request.Form["Price"]);
            car.Id = Convert.ToInt32(Request.Form["Id"]);

            if (car.Make.Length == 0 || car.CarModel.Length == 0 ||
                car.Year <= 0 || car.Colour.Length == 0 ||
                car.Registration.Length == 0 || car.Price <= 0)
            {
                errorMessage = "All the fields are required";
                return;
            }


            try
            {
                string connectionString = "Server=(localdb)\\MSSQLLocalDB; database=HondaDealership;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE Car" +
                                 " SET Make=@Make, CarModel=@CarModel, Year=@Year, Colour=@Colour, Registration=@Registration, Price=@Price" + 
                                 " WHERE Id=@Id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", car.Id);
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

            Response.Redirect("/Admin/InStockCarsAdmin");
        }
    }
}
