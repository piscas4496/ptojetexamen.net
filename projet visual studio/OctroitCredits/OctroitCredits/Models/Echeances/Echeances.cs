using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OctroitCredits.Models.Echeances
{
    public class Echeances
    {
        //function for 
        string connectionString = "Data Source=PISCAS\\SA;Initial Catalog=CreditSoft;Integrated Security=True";
        public IEnumerable<EcheanceModel> GetAllEcheance()
        {

            var echeancesList = new List<EcheanceModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("fetchAllEcheance", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var echeance = new EcheanceModel();
                    echeance.echeanceId = Convert.ToInt32(dr["id"].ToString());
                    echeance.clientId = Convert.ToInt32(dr["client_id"].ToString());
                    echeance.creditId = Convert.ToInt32(dr["credit_id"].ToString());
                    echeance.montantcredit = Convert.ToInt64(dr["montant"].ToString());
                    echeance.montantpayer = Convert.ToInt64(dr["credit_id"].ToString());
                    echeance.dateEcheance = Convert.ToDateTime(dr["credit_id"].ToString());
                    

                    echeancesList.Add(echeance);
                }
                con.Close();
            }
            return echeancesList;
        }

        public void CreateEcheance(EcheanceModel echeance)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_echeance", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@id", client.id);
                cmd.Parameters.AddWithValue("@client_id", echeance.clientId);
                cmd.Parameters.AddWithValue("@credit_id", echeance.creditId);
                cmd.Parameters.AddWithValue("@montantcredit", echeance.montantcredit);
                cmd.Parameters.AddWithValue("@montantpayer", echeance.montantpayer);
                cmd.Parameters.AddWithValue("@dateecheance", echeance.dateEcheance);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void UpdateEcheance(EcheanceModel echeance)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_updateecheance", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", echeance.echeanceId);
                cmd.Parameters.AddWithValue("@client_id", echeance.clientId);
                cmd.Parameters.AddWithValue("@cerdit_id", echeance.clientId);
                cmd.Parameters.AddWithValue("@montantcredit", echeance.montantcredit);
                cmd.Parameters.AddWithValue("@montantpayer", echeance.montantpayer);
                cmd.Parameters.AddWithValue("@dateecheance", echeance.dateEcheance);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void DeleteEcheance(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var client = new EcheanceModel();
                SqlCommand cmd = new SqlCommand("delete_echeance", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", client.echeanceId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public EcheanceModel GetEcheanceById(int? Id)
        {
            var echeance = new EcheanceModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetecheanceById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", Id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                //cmd.ExecuteNonQuery();
                while (dr.Read())
                {
                    echeance.echeanceId = Convert.ToInt32(dr["id"].ToString());
                    echeance.clientId = Convert.ToInt32(dr["client_id"].ToString());
                    echeance.creditId = Convert.ToInt32(dr["credit_id"].ToString());
                    echeance.montantcredit = Convert.ToInt64(dr["montant"].ToString());
                    echeance.montantpayer = Convert.ToInt64(dr["credit_id"].ToString());
                    echeance.dateEcheance = Convert.ToDateTime(dr["credit_id"].ToString());

                }
                con.Close();
            }
            return echeance;

        }

        public List<ClientModel> GetClient()
        {
            List<ClientModel> clientList = new List<ClientModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("getNameCLient", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            clientList.Add(new ClientModel
                            {
                                Id = Convert.ToInt32(dr["id"].ToString()),
                                Noms = dr["noms"].ToString(),
                                //sigle = dr["Sigle"].ToString(),
                            });

                        }
                    }
                    con.Close();
                }

            }
            return clientList;
        }

        public List<CreditModel> GetCredit()
        {
            List<CreditModel> creditList = new List<CreditModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("getSelectCredit", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            creditList.Add(new CreditModel
                            {
                                CreditId = Convert.ToInt32(dr["id"].ToString()),
                                relevespaie = dr["relevespaie"].ToString(),
                                //sigle = dr["Sigle"].ToString(),
                            });

                        }
                    }
                    con.Close();
                }

            }
            return creditList;
        }

    }
}

