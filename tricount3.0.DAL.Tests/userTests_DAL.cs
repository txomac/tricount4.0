using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tricount.DAL.Tests
{
    public class userTests_DAL
    {
        [Fact]
        public void User_ValiderConstructeur()
        {
            var ID = 1;
            var Nom = "Thomas";
            var Organisateur = 5;
            var Dettes = 6;
            var Depenses = 6;
            var ID_Soiree = 6;

            var u = new user_DAL(ID, Nom, Organisateur, Dettes, Depenses, ID_Soiree);

            Assert.Equals(ID, u.id);
            Assert.Equals(Nom, u.nom);
            Assert.Equals(Organisateur, u.organisteur);
            Assert.Equals(Dettes, u.depenses);
            Assert.Equals(ID_Soiree, u.id_soiree);
            Assert.NotNull(u);
        }

        [Fact]
        public void Soiree_GetAll_Valider()
        {
            var ID = 1;
            var Nom = "Thomas";
            var Organisateur = 5;
            var Dettes = 6;
            var Depenses = 6;
            var ID_Soiree = 6;
            var u = new user_DAL(ID, Nom, Organisateur, Dettes, Depenses, ID_Soiree);
            var expected = $"({ID}; {Nom}; {Organisateur}; {Dettes}; {Depenses}; {ID_Soiree};)";

            var depotUser = new userDepot_DAL();

            var result = depotUser.GetAll();

            Assert.IsNotEmpty(result);
            Assert.Equals(expected, result);
            Assert.NotNull(result);
        }

        [Fact]
        public void Soiree_GetByID_Valider()
        {
            var ID = 1;
            var Nom = "Thomas";
            var Organisateur = 5;
            var Dettes = 6;
            var Depenses = 6;
            var ID_Soiree = 6;
            var u = new user_DAL(ID, Nom, Organisateur, Dettes, Depenses, ID_Soiree);
            var expected = $"({ID}; {Nom}; {Organisateur}; {Dettes}; {Depenses}; {ID_Soiree};)";

            var depotUser = new userDepot_DAL();

            var result = depotUser.GetByID(u.id);

            Assert.Equals(expected, result);
            Assert.NotNull(result);
        }

        [Fact]
        public void Soiree_Insert_Valider()
        {
            var ID = 1;
            var Nom = "Thomas";
            var Organisateur = 5;
            var Dettes = 6;
            var Depenses = 6;
            var ID_Soiree = 6;
            var u = new user_DAL(ID, Nom, Organisateur, Dettes, Depenses, ID_Soiree);
            var expected = $"({ID}; {Nom}; {Organisateur}; {Dettes}; {Depenses}; {ID_Soiree};)";

            var depotUser = new userDepot_DAL();

            var result = depotUser.Insert(u);

            Assert.Equals(expected, result);
            Assert.True(result != null);
        }

        [Fact]
        public void Soiree_Update_Valider()
        {
            var ID = 1;
            var Nom = "Thomas";
            var Organisateur = 5;
            var Dettes = 6;
            var Depenses = 6;
            var ID_Soiree = 6;
            var u = new user_DAL(ID, Nom, Organisateur, Dettes, Depenses, ID_Soiree);
            var expected = $"({ID}; {Nom}; {Organisateur}; {Dettes}; {Depenses}; {ID_Soiree};)";

            var depotUser = new userDepot_DAL();

            var result = depotUser.Update(u);

            Assert.Equals(expected, result);
            Assert.True(result != null);
        }

        [Fact]
        public void Soiree_Delete_Valider()
        {
            var ID = 1;
            var Nom = "Thomas";
            var Organisateur = 5;
            var Dettes = 6;
            var Depenses = 6;
            var ID_Soiree = 6;
            var u = new user_DAL(ID, Nom, Organisateur, Dettes, Depenses, ID_Soiree);
            var expected = $"({ID}; {Nom}; {Organisateur}; {Dettes}; {Depenses}; {ID_Soiree};)";

            var depotUser = new userDepot_DAL();

            depotUser.Delete(u);

            Assert.True(u == null);
        }
    }
}
