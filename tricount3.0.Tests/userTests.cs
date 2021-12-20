using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Tricount;

namespace Tricount.Tests
{
    public class userTests
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

            var u = new user(ID, Nom, Organisateur, Dettes, Depenses, ID_Soiree);

            Assert.Equals(ID, u.id);
            Assert.Equals(Nom, u.nom);
            Assert.Equals(Organisateur, u.organisteur);
            Assert.Equals(Dettes, u.depenses);
            Assert.Equals(ID_Soiree, u.id_soiree);
            Assert.NotNull(u);
        }
    }
}
