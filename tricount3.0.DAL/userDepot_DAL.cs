using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tricount.DAL
{
    public class userDepot_DAL : Depot_DAL<user_DAL>
    {
        public override List<user_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, nom, depenses, id_soiree, dettes from user";
            var reader = commande.ExecuteReader();

            var listeUser = new List<user_DAL>();

            while (reader.Read())
            {
                var u = new user_DAL(reader.GetInt32(0),
                                                    reader.GetString(1),
                                                    reader.GetInt32(2),
                                                    reader.GetInt32(3),
                                                    reader.GetFloat(4));

                listeUser.Add(u);
            }

            DetruireConnexionEtCommande();

            return listeUser;
        }

        public override user_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, nom, depenses, id_soiree, dettes from user where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            user_DAL u;

            if (reader.Read())
            {
                u = new user_DAL(reader.GetInt32(0),
                                                reader.GetString(1),
                                                reader.GetInt32(2),
                                                reader.GetInt32(3),
                                                reader.GetFloat(4));
            }
            else
            {
                throw new Exception($"Pas d'utilisateur avec l'ID {ID}");
            }

            DetruireConnexionEtCommande();

            return u;
        }

        public override user_DAL Insert(user_DAL user)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into user(nom, depenses, id_soiree, dettes)" + " values (@NOM, @ORGANISATEUR, @DETTES, @DEPENSES, @ID_SOIREE); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@NOM", user.nom));
            commande.Parameters.Add(new SqlParameter("@DEPENSES", user.depenses));
            commande.Parameters.Add(new SqlParameter("@ID_SOIREE", user.id_soiree));
            commande.Parameters.Add(new SqlParameter("@DETTES", user.dettes));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            user.nom = GetByID(ID).nom;
            user.depenses = GetByID(ID).depenses;
            user.id_soiree = GetByID(ID).id_soiree;
            user.dettes = GetByID(ID).dettes;
            DetruireConnexionEtCommande();

            return user;
        }

        public override user_DAL Update(user_DAL user)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update user set nom=@NOM, depenses=@DEPENSES, id_soiree=@ID_SOIREE, dettes=@DETTES where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@NOM", user.nom));
            commande.Parameters.Add(new SqlParameter("@DEPENSES", user.depenses));
            commande.Parameters.Add(new SqlParameter("@ID_SOIREE", user.id_soiree));
            commande.Parameters.Add(new SqlParameter("@DETTES", user.dettes));

            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de mettre à jour l'utilisateur d'ID {user.id}");
            }

            user.nom = GetByID(user.id).nom;

            DetruireConnexionEtCommande();

            return user;
        }

        public override void Delete(user_DAL user)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from user where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", user.id));

            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de supprimer l'utilisateur d'ID {user.id}");
            }

            DetruireConnexionEtCommande();
        }

        public List<user_DAL> GetUserBySoiree(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, nom, depenses, id_soiree, dettes from user where ID_SOIREE=@ID_SOIREE";
            commande.Parameters.Add(new SqlParameter("@ID_SOIREE", ID));
            var reader = commande.ExecuteReader();

            user_DAL u;
            var listeAllUser = new List<user_DAL>();

            while (reader.Read())
            {
                u = new user_DAL(reader.GetInt32(0),
                                                reader.GetString(1),
                                                reader.GetInt32(2),
                                                reader.GetInt32(3),
                                                reader.GetFloat(4));
                listeAllUser.Add(u);
            }

            DetruireConnexionEtCommande();

            return listeAllUser;
        }
    }
}