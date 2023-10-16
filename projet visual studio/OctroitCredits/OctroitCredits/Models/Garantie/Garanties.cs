
using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using OctroitCredits.Models;
using System.Data;

namespace OctroitCredits.Controllers
{
    public class Garantie
    {
        string connectionString = "Data Source=PISCAS\\SA;Initial Catalog=CreditSoft;Integrated Security=True";

        public IEnumerable<GarantieModel> GetAllGarantie()
        {
            var listGarantie = new List<GarantieModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllGarantie", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var garantie = new GarantieModel();

                    garantie.Id = Convert.ToInt32(dr["id"].ToString());
                    garantie.Client_id = Convert.ToInt32(dr["client_id"].ToString());
                    garantie.Credit_id = Convert.ToInt32(dr["credit_id"].ToString());
                    garantie.Infogarantie = dr["infogarantie"].ToString();
                    garantie.Valeurestimee = Convert.ToDecimal(dr["valeurestimee"].ToString());

                    listGarantie.Add(garantie);
                }
                con.Close();
            }
            return listGarantie;
        }
        public void CreateGarantie(GarantieModel garantie)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_garanties", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@client_id", garantie.Client_id);
                cmd.Parameters.AddWithValue("@credit_id", garantie.Credit_id);
                cmd.Parameters.AddWithValue("@infogarantie", garantie.Infogarantie);
                cmd.Parameters.AddWithValue("@valeurestimee", garantie.Valeurestimee);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateGarantie(GarantieModel garantie)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_updategaranties", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", garantie.Id);
                cmd.Parameters.AddWithValue("@client_id", garantie.Client_id);
                cmd.Parameters.AddWithValue("@credit_id", garantie.Credit_id);
                cmd.Parameters.AddWithValue("@infogarantie", garantie.Infogarantie);
                cmd.Parameters.AddWithValue("@valeurestimee", garantie.Valeurestimee);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteGarantie(int? Id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("deleteGarantie", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", Id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public GarantieModel GetGarantieById(int? Id)
        {
            var garantie = new GarantieModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetGarantieById", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", Id);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    garantie.Id = Convert.ToInt32(dr["id"].ToString());
                    garantie.Client_id = Convert.ToInt32(dr["client_id"].ToString());
                    garantie.Credit_id = Convert.ToInt32(dr["credit_id"].ToString());
                    garantie.Infogarantie = dr["infogarantie"].ToString();
                    garantie.Valeurestimee = Convert.ToDecimal(dr["valeurestimee"].ToString());

                }

                con.Close();
            }
            return garantie;
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
        public List<CompteModel> GetCompte()
        {
            List<CompteModel> compteList = new List<CompteModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("getNumCompte", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            compteList.Add(new CompteModel
                            {
                                id = Convert.ToInt32(dr["id"].ToString()),
                                numCompte = dr["numcompte"].ToString(),
                                //sigle = dr["Sigle"].ToString(),
                            });

                        }
                    }
                    con.Close();
                }

            }
            return compteList;
        }
    }
}

