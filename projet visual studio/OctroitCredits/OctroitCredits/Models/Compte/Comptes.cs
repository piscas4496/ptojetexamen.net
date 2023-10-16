using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OctroitCredits.Models.Comptes
{
    public class Comptes
    {
        //function for 
        string connectionString = "Data Source=PISCAS\\SA;Initial Catalog=CreditSoft;Integrated Security=True";
        public IEnumerable<CompteModel> GetAllCompte()
        {

            var compteList = new List<CompteModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("fetchAllcompte", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var compte = new CompteModel();
                    compte.id = Convert.ToInt32(dr["id"].ToString());
                    compte.clientId = Convert.ToInt32(dr["client_id"].ToString());
                    compte.numCompte = dr["numcompte"].ToString();
                    compte.montant = Convert.ToInt64(dr["montant"].ToString());
                    compte.libelle = dr["libelle"].ToString();
                    compte.dateOperation = Convert.ToDateTime(dr["dateoperation"].ToString());                 
                    
                    compteList.Add(compte);
                }
                con.Close();
            }
            return compteList;
        }

        public void CreateCompte(CompteModel compte)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_compte", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@id", client.id);
                cmd.Parameters.AddWithValue("@client_id", compte.clientId);
                cmd.Parameters.AddWithValue("@numcompte", compte.numCompte);
                cmd.Parameters.AddWithValue("@montant", compte.montant);
                cmd.Parameters.AddWithValue("@libelle", compte.libelle);
                cmd.Parameters.AddWithValue("@dateoperation", compte.dateOperation);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void UpdateCompte(CompteModel compte)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_updatecompte", con);
                cmd.Parameters.AddWithValue("@client_id", compte.clientId);
                cmd.Parameters.AddWithValue("@numcompte", compte.numCompte);
                cmd.Parameters.AddWithValue("@montant", compte.montant);
                cmd.Parameters.AddWithValue("@libelle", compte.libelle);
                cmd.Parameters.AddWithValue("@dateoperation", compte.dateOperation);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void DeleteCompte(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var compte = new CompteModel();
                SqlCommand cmd = new SqlCommand("delete_compte", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", compte.id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public CompteModel GetCompteById(int? Id)
        {
            var compte = new CompteModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetCompteById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", Id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                //cmd.ExecuteNonQuery();
                while (dr.Read())
                {
                    compte.id = Convert.ToInt32(dr["id"].ToString());
                    compte.clientId = Convert.ToInt32(dr["client_id"].ToString());
                    compte.numCompte = dr["numcompte"].ToString();
                    compte.montant = Convert.ToInt64(dr["montant"].ToString());
                    compte.libelle = dr["libelle"].ToString();
                    compte.dateOperation = Convert.ToDateTime(dr["dateoperation"].ToString());

                }
                con.Close();
            }
            return compte;

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

    }

}

