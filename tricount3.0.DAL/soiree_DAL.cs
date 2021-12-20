using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tricount.DAL
{
    public class soiree_DAL
    {
        public int id { get; set; }

        public string name { get; set; }

        public soiree_DAL(string Name)
        {
            name = Name;
        }

        public soiree_DAL(int ID, string Name)
            : this(Name)
        {
            id = ID;
        }
    }
}
