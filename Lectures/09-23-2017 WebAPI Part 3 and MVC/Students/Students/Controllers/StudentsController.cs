using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Entities;
using Students.Models;

namespace Students.Controllers
{
    
    // this controller will live at the url https://localhost:someport/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        // this is NOT the right way to do this long term.
        // preview: assignment 6, use dependency injection instead
        private static List<StudentModel> students = new List<StudentModel>();

        [HttpGet]
        public IEnumerable<StudentEntity> Get()
        {
            return students.Select(studentModel => studentModel.ToEntity());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOne(int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }

            var studentEntity = students[id].ToEntity();
            studentEntity.Views = students[id].Views.Count;

            return new JsonResult(studentEntity);
        }

        [HttpPost]
        public IActionResult Post([FromBody] StudentEntity student)
        {
            if (!ModelState.IsValid)
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = "Your first or last name wasn't long enough. Please try again."
                };
            }

            students.Add(student.ToModel());

            return new JsonResult(student);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromBody] StudentEntity student, int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return new StatusCodeResult((int) HttpStatusCode.NotFound);
            }

            if (!ModelState.IsValid)
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = "Your first or last name wasn't long enough. Please try again."
                };
            }

            students[id] = student.ToModel();

            return new JsonResult(student);
        }

        [HttpPut("{id:int}")]
        public IActionResult Patch([FromBody] StudentEntity student, int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }

            if (!ModelState.IsValid)
            {
                return new ContentResult()
                {
                    StatusCode = (int) HttpStatusCode.BadRequest,
                    Content = "Your first or last name wasn't long enough. Please try again."
                };
            }

            if (student.FirstName != null)
            {
                students[id].FirstName = student.FirstName;
            }

            if (student.LastName != null)
            {
                students[id].LastName = student.LastName;
            }

            return new JsonResult(students[id].ToEntity());
        }

        [HttpDelete("{id:int}")]
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