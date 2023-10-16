using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using OctroitCredits.Models;

namespace OctroitCredits.Controllers
{
    public class Taux
    {
        string connectionString = "Data Source=PISCAS\\SA;Initial Catalog=CreditSoft;Integrated Security=True";

        public IEnumerable<TauxModel> GetAllTaux()
        {
            var listTaux = new List<TauxModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllTaux", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var taux = new TauxModel();

                    taux.Id = Convert.ToInt32(dr["id"].ToString());
                    taux.Categoriecredit = dr["categoriecredit"].ToString();
                    taux.Taux_annuel = Convert.ToDecimal(dr["taux_annuel"].ToString());
                    taux.Taux_mensuel = Convert.ToDecimal(dr["taux_mensuel"].ToString());


                    listTaux.Add(taux);
                }
                con.Close();
            }
            return listTaux;
        }
        public void CreateTaux(TauxModel taux)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_taux", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@categoriecredit", taux.Categoriecredit);
                cmd.Parameters.AddWithValue("@taux_annuel", taux.Taux_annuel);
                cmd.Parameters.AddWithValue("@taux_mensuel", taux.Taux_mensuel);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateTaux(TauxModel taux)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_updatetaux", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", taux.Id);
                cmd.Parameters.AddWithValue("@categoriecredit", taux.Categoriecredit);
                cmd.Parameters.AddWithValue("@taux_annuel", taux.Taux_annuel);
                cmd.Parameters.AddWithValue("@taux_mensuel", taux.Taux_mensuel);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteTaux(int? Id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("deleteTaux", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", Id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public TauxModel GetTauxById(int? Id)
        {
            var taux = new TauxModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetclientById", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", Id);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    taux.Id = Convert.ToInt32(dr["id"].ToString());
                    taux.Categoriecredit = dr["categoriecredit"].ToString();
                    taux.Taux_annuel = Convert.ToDecimal(dr["taux_annuel"].ToString());
                    taux.Taux_mensuel = Convert.ToDecimal(dr["taux_mensuel"].ToString());

                }

                con.Close();
            }
            return taux;
        }
    }
}

