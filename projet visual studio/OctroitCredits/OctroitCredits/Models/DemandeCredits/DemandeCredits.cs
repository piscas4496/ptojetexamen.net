using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OctroitCredits.Models.DemandeCredits
{
    public class DemandeCredits
    {
        //function for 
        string connectionString = "Data Source=PISCAS\\SA;Initial Catalog=CreditSoft;Integrated Security=True";
        public IEnumerable<DemmandeModel> GetAllDemmande()
        {

            var demmandeList = new List<DemmandeModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("fetchADemmandes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var demmande = new DemmandeModel();
                    demmande.demandeId= Convert.ToInt32(dr["id"].ToString());
                    demmande.clientId = Convert.ToInt32(dr["client_id"].ToString());                
                    demmande.montant = Convert.ToInt64(dr["montant"].ToString());
                    demmande.motif = dr["motif"].ToString();
                    demmande.duree = dr["duree"].ToString();
    
                    demmandeList.Add(demmande);
                }
                con.Close();
            }
            return demmandeList;
        }

        public void CreateDemmande(DemmandeModel demmande)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_demande", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@id", client.id);
                cmd.Parameters.AddWithValue("@client_id", demmande.clientId);
                cmd.Parameters.AddWithValue("@montant", demmande.montant);
                cmd.Parameters.AddWithValue("@duree", demmande.duree);
                cmd.Parameters.AddWithValue("@motif", demmande.motif);
                cmd.Parameters.AddWithValue("@datedemande", demmande.dateDemande);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void UpdateDemmande(DemmandeModel demmande)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_updatedemande", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", demmande.demandeId);
                cmd.Parameters.AddWithValue("@client_id", demmande.clientId);
                cmd.Parameters.AddWithValue("@montant", demmande.montant);
                cmd.Parameters.AddWithValue("@duree", demmande.duree);
                cmd.Parameters.AddWithValue("@motif", demmande.motif);
                cmd.Parameters.AddWithValue("@datedemande", demmande.dateDemande);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void DeleteDemmande(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var demmande= new DemmandeModel();
                SqlCommand cmd = new SqlCommand("delete_demmande", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", demmande.demandeId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public DemmandeModel GetDemmandeById(int? Id)
        {
            var demmande = new DemmandeModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetDemmandeById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", Id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                //cmd.ExecuteNonQuery();
                while (dr.Read())
                {
                    demmande.demandeId = Convert.ToInt32(dr["id"].ToString());
                    demmande.clientId = Convert.ToInt32(dr["client_id"].ToString());
                    demmande.montant = Convert.ToInt64(dr["adresse"].ToString());
                    demmande.motif = dr["motif"].ToString();
                    demmande.duree = dr["duree"].ToString();
                    demmande.dateDemande = Convert.ToDateTime(dr["adresse"].ToString());

                }
                con.Close();
            }
            return demmande;

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

