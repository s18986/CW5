using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zestaw_5_podejscie_4.Models;
using Zestaw_5_podejscie_4.Requests;
using Zestaw_5_podejscie_4.Response;

namespace Zestaw_5_podejscie_4.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            Student st = new Student();
            st.FirstName = request.FirstName;

            var response = new EnrollStudentResponse();
            response.LastName = request.LastName;
            response.Semester = request.Semester;
            response.StartDate = request.Birthdate;
            response.Semester = 1;

           
            using (var con = new SqlConnection())
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                con.Open();
                var tran = con.BeginTransaction();
                //1.Studia
                com.CommandText = "Select  IdStudy from Studies where Name=@name";
                com.Parameters.AddWithValue("name", request.Studies);
                var reader = com.ExecuteReader();
                com.Parameters.Clear();
                if (!reader.HasRows)
                {
                    reader.Close();
                    tran.Rollback();
                    return BadRequest("Nie ma takich studiow");
                }
            }

            return Ok(response);
        }
    }
}