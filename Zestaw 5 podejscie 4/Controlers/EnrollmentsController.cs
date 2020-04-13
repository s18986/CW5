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
using Zestaw_5_podejscie_4.Services;

namespace Zestaw_5_podejscie_4.Controlers
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
        private SqlStudentServerDbServicecs _service = new SqlStudentServerDbServices();
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
            response.FirstName = request.FirstName;
            response.Studies = request.Studies;
            response.IndexNumber = request.IndexNumber;
            response.Semester = 1;
        _service


            // con.Dispose();

        return Ok(response);
        }
        [Route("api/enrollments/promotions")]
        [HttpPost]
        public IActionResult promote(PromoteStudentRequest request)
        {
            if (!ModelState.IsValid)
            {
                var d = ModelState;
            }
            Student st = new Student();
            st.FirstName = "Michał";
            st.LastName = "Kozak";
            st.Semester = 1;
            st.Studies = "Informatyka";
            st.IndexNumber = "s19084";
            st.Birthdate =DateTime.Now;
            return Ok(st);
        }
    }
}