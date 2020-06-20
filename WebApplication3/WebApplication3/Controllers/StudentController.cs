using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{

    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase//Controller
    {
        [HttpGet]
        public IActionResult GetStudent()
        {
            var db = new s17245Context();
            var res = db.Student
                .OrderBy(d => d.LastName)
                .Select(stud => new
                { 
                     stud.IndexNumber
                    ,stud.LastName
                    ,stud.FirstName

                });

            return Ok(res);
        }
        /*        http://localhost:5000/api/students/s17777
                {
                 "IndexNumber": "s17777"
                , "FirstName" : "Grzegorz"
                , "LastName" : "Wałaszek"
                , "BirthDate" : "1410-07-15"
                , "IdEnrollment" : "4"
                }
         */

        [HttpPost]
        [Route("{id}")]
        public IActionResult UpdateStudent(Student student, string id)
        {
            var db = new s17245Context();
            var stud1 = new Student
            {
                  IndexNumber = id
                , FirstName = student.FirstName
                , LastName = student.LastName
                , BirthDate = student.BirthDate
                , IdEnrollment = student.IdEnrollment
            };

            db.Attach(stud1);
            db.Entry(stud1).Property("FirstName").IsModified = true;

            db.SaveChanges();
            return Ok(stud1);
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(string id)
        {
            var db = new s17245Context();

            var stud = db.Student.
                Where(stud => stud.IndexNumber == id).
                First();
            db.Student.Remove(stud);
            db.SaveChanges();
            return Ok("student usunięty");
        }
    }
}