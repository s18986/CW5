using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zestaw_5.Models
{
    public class Student
    {
        [RegularExpression("^s[0-9]+$")]
        public String IndexNumber { get; set; }
        [Required]
        [MaxLength(10)]
        public String FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public String LastName { get; set; }

        public DateTime BirthDate { get; set; }
        [Required]
        public String Studies { get; set; }

        public int Semester { get; set; }
    }
}
