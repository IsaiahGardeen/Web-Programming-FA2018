using Hobbits.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hobbits.Entities
{
    public class HobbitEntity
    {
        [MinLength(1)]
        public string Name { get; set; }

        public HobbitModel ToModel()
        {
            return new HobbitModel()
            {
                Name = this.Name
            };
        }
    }
}
