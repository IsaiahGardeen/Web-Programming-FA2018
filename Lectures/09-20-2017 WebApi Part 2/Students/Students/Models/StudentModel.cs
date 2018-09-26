using Students.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Models
{

    /*
     * Models are for storing objects into the database
     * NOT ever visible to the user
     */
    public class StudentModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<string> Views { get; set; } = new List<string>();

        public StudentEntity ToEntity()
        {
            return new StudentEntity
            {
                FirstName = this.FirstName,
                LastName = this.LastName
            };
        }
    }
}
