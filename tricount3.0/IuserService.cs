using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tricount
{
    public interface IuserService
    {
        public List<user> GetAllUser();
        public user GetUserByID(int ID);
        public user Insert(user u);
        public user Update(user u);
        public void Delete(user u);
        public List<user> GetUserBySoiree(int ID);
    }
}
