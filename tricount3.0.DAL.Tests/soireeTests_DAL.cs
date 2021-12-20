using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tricount.DAL.Tests
{
    public class soireeTests_DAL
    {
        [Fact]
        public void Soiree_ValiderConstructeur()
        {
            var ID = 1;
            var NB_Participant = 10;
            var Total_Soiree = 5;
            var Moyenne_User = 6;

            var s = new soiree_DAL(ID, NB_Participant, Total_Soiree, Moyenne_User);

            Assert.Equals(ID, s.id);
            Assert.Equals(NB_Participant, s.nb_participant);
            Assert.Equals(Total_Soiree, s.total_soiree);
            Assert.Equals(Moyenne_User, s.moyenne_user);
            Assert.NotNull(s);
        }

        [Fact]
        public void Soiree_GetAll_Valider()
        {
            var ID = 1;
            var NB_Participant = 10;
            var Total_Soiree = 5;
            var Moyenne_User = 6;
            var s = new soiree_DAL(ID, NB_Participant, Total_Soiree, Moyenne_User);
            var expected = $"({ID}; {NB_Participant}; {Total_Soiree}; {Moyenne_User};)";

            var depotSoiree = new soireeDepot_DAL();

            var result = depotSoiree.GetAll();

            Assert.IsNotEmpty(result);
            Assert.Equals(expected, result);
            Assert.NotNull(result);
        }

        [Fact]
        public void Soiree_GetByID_Valider()
        {
            var ID = 1;
            var NB_Participant = 10;
            var Total_Soiree = 5;
            var Moyenne_User = 6;
            var s = new soiree_DAL(ID, NB_Participant, Total_Soiree, Moyenne_User);
            var expected = $"({ID}; {NB_Participant}; {Total_Soiree}; {Moyenne_User};)";

            var depotSoiree = new soireeDepot_DAL();

            var result = depotSoiree.GetByID(s.id);

            Assert.Equals(expected, result);
            Assert.NotNull(result);
        }

        [Fact]
        public void Soiree_Insert_Valider()
        {
            var ID = 1;
            var NB_Participant = 10;
            var Total_Soiree = 5;
            var Moyenne_User = 6;
            var s = new soiree_DAL(ID, NB_Participant, Total_Soiree, Moyenne_User);
            var expected = $"({ID}; {NB_Participant}; {Total_Soiree}; {Moyenne_User};)";

            var depotSoiree = new soireeDepot_DAL();

            var result = depotSoiree.Insert(s);

            Assert.Equals(expected, result);
            Assert.True(result != null);
        }

        [Fact]
        public void Soiree_Update_Valider()
        {
            var ID = 1;
            var NB_Participant = 10;
            var Total_Soiree = 5;
            var Moyenne_User = 6;
            var s = new soiree_DAL(ID, NB_Participant, Total_Soiree, Moyenne_User);
            var expected = $"({ID}; {NB_Participant}; {Total_Soiree}; {Moyenne_User};)";

            var depotSoiree = new soireeDepot_DAL();

            var result = depotSoiree.Update(s);

            Assert.Equals(expected, result);
            Assert.True(result != null);
        }

        [Fact]
        public void Soiree_Delete_Valider()
        {
            var ID = 1;
            var NB_Participant = 10;
            var Total_Soiree = 5;
            var Moyenne_User = 6;
            var s = new soiree_DAL(ID, NB_Participant, Total_Soiree, Moyenne_User);
            var expected = $"({ID}; {NB_Participant}; {Total_Soiree}; {Moyenne_User};)";

            var depotSoiree = new soireeDepot_DAL();

            depotSoiree.Delete(s);

            Assert.True(s == null);
        }
    }
}
