using Gargoyles.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gargoyles.Services
{
    public class GargoyleDatabase
    {
        // I am breaking a rule here for the sake of the lecture! Use a GargoyleModel in your assignment.
        public List<GargoyleEntity> GargoyleEntities { get; private set; } = new List<GargoyleEntity>();
    }
}
