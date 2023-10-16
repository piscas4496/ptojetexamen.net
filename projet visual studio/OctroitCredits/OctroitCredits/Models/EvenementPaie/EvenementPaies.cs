using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using OctroitCredits.Models;

namespace OctroitCredits.Controllers
{
    public class EvenementPaie
    {
        string connectionString = "Data Source=PISCAS\\SA;Initial Catalog=CreditSoft;Integrated Security=True";

        public IEnumerable<EvenementModel> GetAllEvenement()
        {
            var listEvenement = new List<EvenementModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllEvenement", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var evenement = new EvenementModel();

                    evenement.Id = Convert.ToInt32(dr["id"].ToString());
                    evenement.Client_id = Convert.ToInt32(dr["client_id"].ToString());
                    evenement.Credit_id = Convert.ToInt32(dr["credit_id"].ToString());
                    evenement.Type_evenement = dr["type_evenement"].ToString();
                    evenement.Penalite = Convert.ToDecimal(dr["penalite"].ToString());
                    evenement.Date_evenement = Convert.ToDateTime(dr["date_evenement"].ToString());


                    listEvenement.Add(evenement);
                }
                con.Close();
            }
            return listEvenement;
        }

        public void CreateEvenement(EvenementModel evenement)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_evenement", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@client_id", evenement.Client_id);
                cmd.Parameters.AddWithValue("@credit_id", evenement.Credit_id);
                cmd.Parameters.AddWithValue("@type_evenement", evenement.Type_evenement);
                cmd.Parameters.AddWithValue("@penalite", evenement.Penalite);
                cmd.Parameters.AddWithValue("@date_evenement", evenement.Date_evenement);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateEvenement(EvenementModel evenement)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_updateevenement", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", evenement.Id);
                cmd.Parameters.AddWithValue("@client_id", evenement.Client_id);
                cmd.Parameters.AddWithValue("@credit_id", evenement.Credit_id);
                cmd.Parameters.AddWithValue("@type_evenement", evenement.Type_evenement);
                cmd.Parameters.AddWithValue("@penalite", evenement.Penalite);
                cmd.Parameters.AddWithValue("@date_evenement", evenement.Date_evenement);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteEvenement(int? Id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("deleteEvenement", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", Id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public EvenementModel GetEvenementById(int? Id)
        {
            var evenement = new EvenementModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetEvenementById", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", Id);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    evenement.Id = Convert.ToInt32(dr["id"].ToString());
                    evenement.Client_id = Convert.ToInt32(dr["client_id"].ToString());
                    evenement.Credit_id = Convert.ToInt32(dr["credit_id"].ToString());
                    evenement.Type_evenement = dr["type_evenement"].ToString();
                    evenement.Penalite = Convert.ToDecimal(dr["penalite"].ToString());
                    evenement.Date_evenement = Convert.ToDateTime(dr["date_evenement"].ToString());

                }

                con.Close();
            }
            return evenement;
        }
    }
}

