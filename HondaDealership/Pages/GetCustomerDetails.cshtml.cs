using HondaDealership.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System;

namespace HondaDealership.Pages
{
    public class PaymentModel : PageModel
    {
        public Car car = new Car();
        public Guest guest = new Guest();
        public string errorMessage = "";
        public string successMessage = "";
        public static string Id = ""; 

        public void OnGet()
        {

        }

        public void OnPost()
        {
            guest.FirstName = Request.Form["FirstName"];
            guest.LastName = Request.Form["LastName"];
            guest.MobileNumber = Request.Form["MobileNumber"];
            guest.AddressNumber = Request.Form["AddressNumber"];
            guest.AddressStreet = Request.Form["AddressStreet"];
            guest.AddressCity = Request.Form["AddressCity"];
            guest.AddressPostCode = Request.Form["AddressPostCode"];
            guest.EmailAddress = CheckOutModel.setValueForEmail;

            if (guest.FirstName.Length == 0 || guest.LastName.Length == 0 ||
                guest.MobileNumber.Length == 0 || guest.AddressNumber.Length == 0 ||
                guest.AddressStreet.Length == 0 || guest.AddressCity.Length == 0 ||
                guest.AddressPostCode.Length == 0)
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
                    string sql = "INSERT INTO Guest" +
                                 "(FirstName, LastName, MobileNumber, AddressNumber," +
                                 " AddressStreet, AddressCity, AddressPostCode, EmailAddress) VALUES " +
                                 "(@FirstName, @LastName, @MobileNumber, @AddressNumber," +
                                 " @AddressStreet, @AddressCity, @AddressPostCode, @EmailAddress);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", guest.FirstName);
                        command.Parameters.AddWithValue("@LastName", guest.LastName);
                        command.Parameters.AddWithValue("@MobileNumber", guest.MobileNumber);
                        command.Parameters.AddWithValue("@AddressNumber", guest.AddressNumber);
                        command.Parameters.AddWithValue("@AddressStreet", guest.AddressStreet);
                        command.Parameters.AddWithValue("@AddressCity", guest.AddressCity);
                        command.Parameters.AddWithValue("@AddressPostCode", guest.AddressPostCode);
                        command.Parameters.AddWithValue("@EmailAddress", guest.EmailAddress);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Id = CheckOutModel.setValueForId;
            Response.Redirect("/Checkout");
        }
    }
}
