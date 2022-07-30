using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HondaDealership.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace HondaDealership.Pages
{
    public class CheckOutModel : PageModel
    {
        public Guest guest = new Guest();
        public string errorMessage = "";
        public string successMessage = "";
        //public var obj();
        public static string setValueForEmail = "";
        public static string setValueForId = "";
        public string Id;

        public void OnGet()
        {
            Id = Request.Query["Id"];
            setValueForId = Id;
            //string testing = Id;
        }

        public void OnPost()
        {
            guest.EmailAddress = Request.Form["Email"];
            guest.ConfirmEmailAddress = Request.Form["ConfirmEmail"];

            if (guest.EmailAddress.Length == 0 || guest.ConfirmEmailAddress.Length == 0)
            {
                errorMessage = "All fields are required*";
                return;
            }

            //save the new car into the database
            try
            {
                string connectionString = "Server=(localdb)\\MSSQLLocalDB; database=HondaDealership;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO GuestEmail" +
                                 "(EmailAddress, ConfirmEmailAddress) VALUES " +
                                 "(@EmailAddress, @ConfirmEmailAddress);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@EmailAddress", guest.EmailAddress);
                        command.Parameters.AddWithValue("@ConfirmEmailAddress", guest.ConfirmEmailAddress);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            string testing2 = setValueForId;
            //setValueForId = Id;
            setValueForEmail = guest.EmailAddress.ToString();
            Response.Redirect("/GetCustomerDetails?Id");
        }
    }
}
