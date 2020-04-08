using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zestaw_5.DTO.Requests;
using Zestaw_5.DTO.Responses;
using Zestaw_5.Models;

namespace Zestaw_5.Controllers
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        
        [HttpPost]
        public IActionResult EnrollStudents(Pol2Request request)
        {
            string ConString = "Data Source=db-mssql;Initial Catalog=s18986;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {

                if (request.Semester == null || request.Studies == null)
                {
                    return BadRequest(400);
                }
                com.Connection = con;
                com.CommandText = "UPDATE Student set Semester=Semester+1 where Semester=@semester and Studies=@Studies";
                com.Parameters.AddWithValue("semester", request.Semester);
                com.Parameters.AddWithValue("Studies", request.Studies);

                con.Open();
                con.Close();

                var res = new EnrollStudentResponse();

            }
            return Ok();
        }
    }
}