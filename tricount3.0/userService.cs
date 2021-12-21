using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricount.DAL;

namespace Tricount
{
    public class userService
    {
        private userDepot_DAL depot = new userDepot_DAL();

        public List<user> GetAllUser()
        {
            var user = depot.GetAll()
                    .Select(u => new user(u.id, u.nom, u.depenses, u.id_soiree, u.dettes))
                    .ToList();

            return user;
        }
        public user GetByID(int ID)
        {
            var u = depot.GetByID(ID);
            var user = new user(u.nom, u.depenses, u.id_soiree, u.dettes);
            return user;
        }
        public user Insert(user u)
        {
            var user = new user_DAL(u.nom, u.depenses, u.id_soiree, u.dettes);
            depot.Insert(user);

            return u;
        }
        public user Update(user u)
        {
            var user = new user_DAL(u.id, u.nom, u.depenses, u.id_soiree, u.dettes);
            depot.Update(user);

            return u;
        }
        public void Delete(user u)
        {
            var user = new user_DAL(u.nom, u.depenses, u.id_soiree, u.dettes);
            depot.Delete(user);
        }

        public List<user> GetUserBySoiree(int ID)
        {
            var users = depot.GetUserBySoiree(ID)
                .Select(u => new user(u.id, u.nom, u.depenses, u.id_soiree, u.dettes))
                .ToList();
            return users;
        }
    }
}