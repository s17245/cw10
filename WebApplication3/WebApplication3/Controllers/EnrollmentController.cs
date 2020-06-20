using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.DTOs;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Controllers
{
    [Route("api/enrollments")]
    public class EnrollmentController : ControllerBase //Controller
    {
        [HttpGet]
        public IActionResult EnrollStudent(EnrollStudentRequest enrollStudent)
        {
            var db = new s17245Context();

            var idStudy = db.Studies.Where(s => s.Name == enrollStudent.Studies).First().IdStudy;
            if (!db.Enrollment.Any(e => (e.Semester == 1) && (e.IdStudy == idStudy)))
            {
                var e = new Enrollment();
                e.IdEnrollment = db.Enrollment.Max(e => e.IdEnrollment) + 1;
                e.Semester = 1;
                e.IdStudy = idStudy;
                e.StartDate = DateTime.Now;

                db.Enrollment.Add(e);
            }

            var s = new Student();

            s.IndexNumber = enrollStudent.IndexNumber;
            s.FirstName = enrollStudent.FirstName;
            s.LastName = enrollStudent.LastName;
            s.BirthDate = Convert.ToDateTime(enrollStudent.BirthDate);
            s.IdEnrollment = db.Enrollment.Where(e => (e.Semester == 1) && (e.IdStudy == idStudy)).First().IdEnrollment;

            db.Student.Add(s);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("błąd przy dodawaniu studenta" + ex);
            }
            return Ok();
        }




    } 
}