using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricount.DAL;

namespace Tricount
{
    public class soireeService
    {
        private soireeDepot_DAL depot = new soireeDepot_DAL();

        public List<soiree> GetAllSoiree()
        {
            var soiree = depot.GetAll()
                    .Select(s => new soiree(s.id, s.name))
                    .ToList();

            return soiree;
        }
        public soiree GetSoireeByID(int ID)
        {
            var s = depot.GetByID(ID);
            var soiree = new soiree(s.id, s.name);
            return soiree;
        }
        public soiree Insert(soiree s)
        {
            var soiree = new soiree_DAL(s.name);
            depot.Insert(soiree);

            return s;
        }
        public soiree Update(soiree s)
        {
            var soiree = new soiree_DAL(s.name);
            depot.Update(soiree);

            return s;
        }
        public void Delete(soiree s)
        {
            var soiree = new soiree_DAL(s.name);
            depot.Delete(soiree);
        }
    }
}