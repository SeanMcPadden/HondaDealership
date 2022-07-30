using Dapper;
using HondaDealership.Data_Access;
using HondaDealership.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Stripe;
using System;

namespace HondaDealership.Pages
{
    public class CheckoutModel : PageModel
    {
        public string Id;
        public Car car = new Car();
        public string errorMessage = "";
        public Car selectedCar = new Car();
        public List<Car> cars = new List<Car>();
        public string CustomerEmail = CheckOutModel.setValueForEmail;

        private readonly ApplicationDBContext _context;

        public CheckoutModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Id = PaymentModel.Id;

            try
            {
                string connectionString = "Server=(localdb)\\MSSQLLocalDB; database=HondaDealership;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM listCars WHERE Id=@Id";
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
                                car.Registration = reader.GetString(5);
                                car.Price = reader.GetDecimal(6);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            Response.Redirect("/Paygate");
        }
    }


}





