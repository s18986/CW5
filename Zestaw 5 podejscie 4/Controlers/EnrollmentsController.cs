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

            string ConString = "Data Source=db-mssql;Initial Catalog=s18986;Integrated Security=True";
            Student st = new Student();
            st.FirstName = request.FirstName;

            var response = new EnrollStudentResponse();
            response.LastName = request.LastName;
            response.Semester = request.Semester;
            response.StartDate = request.Birthdate;
            response.Semester = 1;
            
           
            using (var con = new SqlConnection(ConString))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                con.Open();
                var tran = con.BeginTransaction();
                try
                {
                    //1.Studia
                    
                    var reader = com.ExecuteReader();
                    if (!reader.HasRows)
                    {

                        tran.Rollback();
                        return BadRequest("Nie ma takich studiow");
                    }
                    int idstudiow = (int)reader["IdStudy"];
                    reader.Close();
                    Console.WriteLine(idstudiow);
                    
                    com.CommandText = "insert into Student(IndexNumber, FirstName, LastName, BirthDate, IdEnrollment) "
                                          + "values (@indexnumber, @firstname, @lastname, @birthdate, @idenrollment)";
                    com.Parameters.AddWithValue("indexnumber", request.IndexNumber);
                    com.Parameters.AddWithValue("firstname", request.FirstName);
                    com.Parameters.AddWithValue("lastname", request.LastName);
                    com.Parameters.AddWithValue("birthdate", request.Birthdate);
                    com.Parameters.AddWithValue("idenrollment", 10);
                    com.Parameters.Clear();


                    com.ExecuteNonQuery();
                    tran.Commit();
                }catch(SqlException e )
                {
                    Console.WriteLine(e);
                }
                //reader.Close();
            }
            

            return Ok(response);
        }
    }
}