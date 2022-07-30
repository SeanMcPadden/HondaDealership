using HondaDealership.Data_Access;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using HondaDealership.Models;
using System.Linq;

namespace HondaDealership.Pages
{
    public class InStockCarsModel : PageModel
    {
        public string selectedCar = "";

        public List<Car> cars = new List<Car>();

        private readonly ApplicationDBContext _context;

        public InStockCarsModel(ApplicationDBContext context)
        {
            _context = context;
        }


        public void OnGet()
        {
            cars = _context.Car.ToList();
        }
    }

    //        try
    //        {
    //            string connectionString = "server=(localdb)\\MSSQLLocalDB; database=HondaDealership;Integrated Security=True;";
    //            using (SqlConnection connection = new SqlConnection(connectionString))
    //            {
    //                connection.Open();
    //                string sql = "SELECT * FROM listCars";
    //                using (SqlCommand command = new SqlCommand(sql, connection))
    //                {
    //                    using (SqlDataReader reader = command.ExecuteReader())
    //                    {
    //                        while (reader.Read())
    //                        {
    //                            CarInfo car = new CarInfo();
    //                            listCars.id; = reader.GetInt32(0);
    //                            car.make = reader.GetString(1);
    //                            car.carModel = reader.GetString(2);
    //                            car.year = reader.GetInt32(3);
    //                            car.colour = reader.GetString(4);
    //                            car.registration = reader.GetString(5);
    //                            car.price = reader.GetDecimal(6);

    //                            listCars.Add(car);

    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {

    //        }
    //    }
    //}

    //public class CarInfo
    //{
    //    public int id;
    //    public string make;
    //    public string carModel;
    //    public int year;
    //    public string colour;
    //    public string registration;
    //    public decimal price;
    //}
   
}

