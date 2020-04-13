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
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            if(!ModelState.IsValid)
            {
                var d = ModelState;
            }
            Student st = new Student();
            st.FirstName = request.FirstName;

            var response = new EnrollStudentResponse();
            response.LastName = request.LastName;
            response.Semester = request.Semester;
            response.StartDate = request.Birthdate;
            response.Semester = 1;


            using (SqlConnection con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18986;Integrated Security=True"))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                con.Open();
                //var Tran = con.BeginTransaction();
                //1. Walidacja Studiow
                com.CommandText = "select IdStudy from dbo.Studies where Name=@name";
                com.Parameters.AddWithValue("name", request.Studies);
                var dr = com.ExecuteReader();
                if(!dr.Read())
                {
                 //   Tran.Rollback();
                    return BadRequest("Nie ma takich studiow");
                }
                int IdStudies =(int)dr["IdStudy"];
                dr.Close();
                //2. dodanie studenta
                com.CommandText = "insert into Student(IndexNumber, FirstName, LastName, BirthDate, IdEnrollment) "
                                      + "values (@indexnumber, @firstname, @lastname, @birthdate, @idenrollment)";
                com.Parameters.AddWithValue("indexnumber", request.IndexNumber);
                com.Parameters.AddWithValue("firstname", request.FirstName);
                com.Parameters.AddWithValue("lastname", request.LastName);
                com.Parameters.AddWithValue("birthdate", request.Birthdate);
                com.Parameters.AddWithValue("idenrollment", 1);

                com.ExecuteNonQuery();
                //Tran.Commit();
                

            };
            // con.Dispose();

            return Ok(response);
        }
    }
}