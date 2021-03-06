﻿using System;
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

        public StudentsController(IAsyncResult test)
        {

        }

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
        public StudentEntity Post([FromBody] StudentEntity student)
        {
            students.Add(student.ToModel());

            return student;
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromBody] StudentEntity student, int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return new StatusCodeResult((int) HttpStatusCode.NotFound);
            }

            students[id] = student.ToModel();

            return new JsonResult(student);
        }

        [HttpPatch("{id:int}")]
        public IActionResult Patch([FromBody] StudentEntity student, int id)
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