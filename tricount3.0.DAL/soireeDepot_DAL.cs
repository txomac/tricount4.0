using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tricount.DAL
{
    public class soireeDepot_DAL : Depot_DAL<soiree_DAL>
    {
        public override List<soiree_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, name from soiree";
            var reader = commande.ExecuteReader();

            var listeSoiree = new List<soiree_DAL>();

            while (reader.Read())
            {
                var s = new soiree_DAL(reader.GetInt32(0),
                                                    reader.GetString(1));

                listeSoiree.Add(s);
            }

            DetruireConnexionEtCommande();

            return listeSoiree;
        }

        public override soiree_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, name from soiree where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            soiree_DAL s;

            if (reader.Read())
            {
                s = new soiree_DAL(reader.GetInt32(0),
                                                reader.GetString(1));
            }
            else
            {
                throw new Exception($"Pas de soiree avec l'ID {ID}");
            }

            DetruireConnexionEtCommande();

            return s;
        }

        public override soiree_DAL Insert(soiree_DAL soiree)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into soiree(name)" + " values (@NAME); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@NAME", soiree.name));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            soiree.name = GetByID(ID).name;

            DetruireConnexionEtCommande();

            return soiree;
        }

        public override soiree_DAL Update(soiree_DAL soiree)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update soiree set name=@NAME where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", soiree.id));

            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de mettre à jour la soirée d'ID {soiree.id}");
            }

            soiree.name = GetByID(soiree.id).name;

            DetruireConnexionEtCommande();

            return soiree;
        }

        public override void Delete(soiree_DAL soiree)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from soiree where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", soiree.id));

            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de supprimer la soirée d'ID {soiree.id}");
            }

            DetruireConnexionEtCommande();
        }
    }
}