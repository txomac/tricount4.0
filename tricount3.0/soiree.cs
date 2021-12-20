using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tricount
{
    public class soiree
    {
        public int id { get; set; }

        public string name { get; set; }


        public soiree(string Name)
        {
            name = Name;

        }

        public soiree(int ID, string Name)
            : this(Name)
        {
            id = ID;
        }

        public override string ToString()
        {
            return $"ID: {this.id}, Name: {this.name}";
        }
    }
}