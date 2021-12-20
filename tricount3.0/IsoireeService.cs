using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tricount
{
    public interface IsoireeService
    {
        public List<soiree> GetAllSoiree();
        public soiree GetSoireeByID(int ID);
        public soiree Insert(soiree s);
        public soiree Update(soiree s);
        public void Delete(soiree s);
    }
}
