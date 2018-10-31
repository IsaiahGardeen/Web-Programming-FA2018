using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gargoyles.Entities
{
    public class GargoyleEntity
    {
        public string Name { get; set; }

        public DateTime Updated { get; internal set; }

        public string ETag() {
            return this.Updated.ToString();
        }
    }
}
