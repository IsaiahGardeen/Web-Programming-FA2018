using Hobbits.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hobbits.Models
{
    public class HobbitModel
    {
        public string Name { get; set; }

        public HobbitEntity ToEntity()
        {
            return new HobbitEntity()
            {
                Name = this.Name
            };
        }
    }
}
