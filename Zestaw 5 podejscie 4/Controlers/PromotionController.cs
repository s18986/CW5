using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zestaw_5_podejscie_4.Models;
using Zestaw_5_podejscie_4.Requests;
using Zestaw_5_podejscie_4.Response;

namespace Zestaw_5_podejscie_4.Controlers
{
    [Route("api/enrollments/promotions")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        
        [HttpPost]
        public IActionResult EnrollStudent(PromotionStudentRequest request)
        {
            //Student st = new Student();
            //st.IndexNumber = request.IndexNumber;
            var response = new PromoteStudentResponse(); 
            response.IndexNumber = request.IndexNumber;
            return Ok(response);
        }
    }
}
