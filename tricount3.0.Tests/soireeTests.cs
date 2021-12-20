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
    public class soireeTests
    {
        [Fact]
        public void Soiree_ValiderConstructeur()
        {
            var ID = 1;
            var NB_Participant = 10;
            var Total_Soiree = 5;
            var Moyenne_User = 6;

            var s = new soiree(ID, NB_Participant, Total_Soiree, Moyenne_User);

            Assert.Equals(ID, s.id);
            Assert.Equals(NB_Participant, s.nb_participant);
            Assert.Equals(Total_Soiree, s.total_soiree);
            Assert.Equals(Moyenne_User, s.moyenne_user);
            Assert.NotNull(s);
        }
    }
}
