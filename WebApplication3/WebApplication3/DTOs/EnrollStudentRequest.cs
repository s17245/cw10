using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.DTOs
{

    public class EnrollStudentRequest
    {
        //[RegularExpression("^s[0-9]+$")]
        public string IndexNumber { get; set; }

        public string Email { get; set; }

        //[Required(ErrorMessage = "Musisz podać imię")]
        //[MaxLength(100)]
        public string FirstName { get; set; }

        //[Required]
        //[MaxLength(100)]
        public string LastName { get; set; }

        //[Required]
        public string BirthDate { get; set; }

        //[Required]
        public string Studies { get; set; }
    }
}
