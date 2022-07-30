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
    public class ProjectsModel : PageModel
    {
        public string formComplete = "";
        public ProjectApplicants applicant = new ProjectApplicants();
        public string errorMessage = "";

        public void OnGet()
        {
            
        }

        public void OnPost()
        {
            applicant.FullName = Request.Form["FullName"];
            applicant.Email = Request.Form["Email"];
            applicant.HondaModel = Request.Form["HondaModel"];

            if (applicant.FullName.Length == 0 ||
                applicant.Email.Length == 0 ||
                applicant.HondaModel.Length == 0)
            {
                errorMessage = "All fields must first be completed before submitting.";
                return;
            }

            try
            {
                string connectionString = "Server=(localdb)\\MSSQLLocalDB; database=HondaDealership;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO ProjectApplicants" +
                                 "(FullName, Email, HondaModel) VALUES " +
                                 "(@FullName, @Email, @HondaModel);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", applicant.FullName);
                        command.Parameters.AddWithValue("@Email", applicant.Email);
                        command.Parameters.AddWithValue("@HondaModel", applicant.HondaModel);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            formComplete = "Thank you for your application. We will be in touch if your application " +
                            "is successfull.";
        }
    }
}
