using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Entities
{

    /*
     * Entity classes are for sending and receiving data from the user.
     * NOT for saving into a database
     */
    public class StudentEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }


        public int Views { get; internal set; }

        public StudentModel ToModel()
        {
            return new StudentModel
            {
                FirstName = this.FirstName,
                LastName = this.LastName
            };
        }
    }
}
