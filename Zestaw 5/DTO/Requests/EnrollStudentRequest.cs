using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zestaw_5.DTO.Requests
{
    public class EnrollStudentRequest
    {
        public String IndexNumber { get; set; }

        public String Email { get; set; }
      
        [Required(ErrorMessage ="Musisz podac imie")]
        [MaxLength(10)]
        public String FirstName { get; set; }
        [Required(ErrorMessage ="Musisz podac nazwisko")]
        [MaxLength(255)]
        public String LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public String Studies { get; set; }

    }
}
