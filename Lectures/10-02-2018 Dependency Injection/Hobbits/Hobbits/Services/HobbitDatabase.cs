using Hobbits.Entities;
using Hobbits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hobbits.Services
{
    public class HobbitDatabase
    {
        private static List<HobbitModel> hobbits = new List<HobbitModel>();

        static HobbitDatabase()
        {
            hobbits.Add(new HobbitModel() { Name = "Frodo" });
            hobbits.Add(new HobbitModel() { Name = "Sam" });
            hobbits.Add(new HobbitModel() { Name = "Merry" });
            hobbits.Add(new HobbitModel() { Name = "Pippin" });
        }

        public bool Add(HobbitModel hobbit)
        {
            hobbits.Add(hobbit);
            return true;
        }

        public bool Add(HobbitModel hobbit, int id)
        {
            if (id < 0 || id > hobbits.Count)
            {
                return false;
            }

            hobbits[id] = hobbit;

            return true;
        }

        public IEnumerable<HobbitModel> Get()
        {
            return hobbits;
        }

        public HobbitModel Get(int id)
        {
            return hobbits[id];
        }

        public bool Delete(int id)
        {
            hobbits.RemoveAt(id);
            return true;
        }
    }
}
