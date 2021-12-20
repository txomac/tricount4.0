using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tricount
{
    public class user
    {
        public int id { get; set; }

        public string nom { get; set; }
        public int depenses { get; set; }

        public int id_soiree { get; set; }

        public float? dettes { get; set; }

        public user(string Nom, int Depenses, int ID_Soiree, float? Dettes)
        {
            nom = Nom;
            depenses = Depenses;
            id_soiree = ID_Soiree;
            dettes = Dettes;
        }

        public user(int ID, string Nom, int Depenses, int ID_Soiree, float? Dettes)
            : this(Nom, Depenses, ID_Soiree, Dettes)
        {
            id = ID;
        }
    }
}