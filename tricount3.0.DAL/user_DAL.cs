using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tricount.DAL
{
    public class user_DAL
    {
        public int id { get; set; }

        public string nom { get; set; }

        public float depenses { get; set; }

        public int id_soiree { get; set; }

        public float? dettes { get; set; }

        public user_DAL(string Nom, float Depenses, int ID_Soiree, float? Dettes)
        {
            nom = Nom;
            depenses = Depenses;
            id_soiree = ID_Soiree;
            dettes = Dettes;
        }

        public user_DAL(int ID, string Nom, float Depenses, int ID_Soiree, float? Dettes)
            :this(Nom, Depenses, ID_Soiree, Dettes)
        {
            id = ID;
        }
    }
}