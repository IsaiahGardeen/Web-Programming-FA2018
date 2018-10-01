using Spells.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spells.Services
{
    public class SpellsDatabase
    {
        private List<SpellModel> spells = new List<SpellModel>();

        public void Add(string spell)
        {
            this.spells.Add(new SpellModel() { Name = spell });
        }

        public SpellModel Get(int index)
        {
            return this.spells[index];
        }

        public bool Any()
        {
            return spells.Any();
        }

        public int Count()
        {
            return spells.Count();
        }

        public void RemoveAt(int index)
        {
            this.spells.RemoveAt(index);
        }

        public void Mix(string string1, string string2)
        {
            this.spells.Add(string1 + string2);
        }
    }
}
