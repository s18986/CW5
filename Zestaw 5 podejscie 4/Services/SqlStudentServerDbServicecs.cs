using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Zestaw_5_podejscie_4.Requests;
using Zestaw_5_podejscie_4.Response;

namespace Zestaw_5_podejscie_4.Services
{
    public class SqlStudentServerDbServicecs : IStudentDbService
    {
        public EnrollStudentResponse EnrollStudent(EnrollStudentRequest request)
        {
            using (SqlConnection con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18986;Integrated Security=True"))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                con.Open();
                // var Tran = con.BeginTransaction();


                //1. Walidacja Studiow
                com.CommandText = "select IdStudy from dbo.Studies where Name=@name";
                com.Parameters.AddWithValue("name", request.Studies);
                var dr = com.ExecuteReader();
                if (!dr.Read())
                {
                    // Tran.Rollback();
                   // return BadRequest("Nie ma takich studiow");
                }
                int IdStudies = (int)dr["IdStudy"];
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
                // Tran.Commit();


            };
        }

        public PromoteStudentRequest PromoteStudent(PromoteStudentRequest request)
        {
            using (SqlConnection con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18986;Integrated Security=True"))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                con.Open();


                //1. Walidacja Studiow
                com.CommandText = "select IdStudy from dbo.Studies where Name=@name";
                com.Parameters.AddWithValue("name", request.Studies);
                var dr = com.ExecuteReader();
                dr.Close();
                //2. dodanie studenta
                com.CommandText = "update Dbo.Student set semester=semester+1 where  Studies=@studies and semester=@semester)";
                com.Parameters.AddWithValue("studies", request.Studies);
                com.Parameters.AddWithValue("semester", request.Semester);

                com.ExecuteNonQuery();
            }
    }
}
