using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Students.Controllers
{
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }


    // this controller will live at the url https://localhost:someport/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        // this is NOT the right way to do this long term.
        // preview: assignment 6, use dependency injection instead
        private static List<Student> students = new List<Student>();

        [HttpGet]
        public List<Student> Get()
        {
            return students;
        }

        [HttpGet("id:int")]
        public IActionResult GetOne(int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }

            return new JsonResult(students[id]);
        }

        [HttpPost]
        public Student Post([FromBody] Student student)
        {
            students.Add(student);

            return student;
        }

        [HttpPut("id:int")]
        public IActionResult Put([FromBody] Student student, int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return new StatusCodeResult((int) HttpStatusCode.NotFound);
            }

            students[id] = student;

            return new JsonResult(student);
        }

        [HttpPut("id:int")]
        public IActionResult Patch([FromBody] Student student, int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }

            if (student.FirstName != null)
            {
                students[id].FirstName = student.FirstName;
            }

            if (student.LastName != null)
            {
                students[id].LastName = student.LastName;
            }

            return new JsonResult(students[id]);
        }

        [HttpDelete("id:int")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }

            students.RemoveAt(id);

            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}