using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OctroitCredits.Models.Credits
{
    public class Credits
    {
        //function for 
        string connectionString = "Data Source=PISCAS\\SA;Initial Catalog=CreditSoft;Integrated Security=True";
        public IEnumerable<CreditModel> GetAllCredits()
        {

            var creditList = new List<CreditModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("fetchAllCredit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var credit = new CreditModel();
                    credit.CreditId = Convert.ToInt32(dr["id"].ToString());
                    credit.clientId = Convert.ToInt32(dr["client_id"].ToString());
                    credit.compteId = Convert.ToInt32(dr["compte_id"].ToString());
                    credit.montant = Convert.ToInt64(dr["montant"].ToString());
                    credit.duree = dr["duree"].ToString();
                    credit.taux_interet = Convert.ToInt64(dr["taux_interet"].ToString());
                    credit.statut = dr["statut"].ToString();
                    credit.relevespaie = dr["relevespaie"].ToString();
                    credit.datecredit = Convert.ToDateTime(dr["datecredit"].ToString());


                    creditList.Add(credit);
                }
                con.Close();
            }
            return creditList;
        }


        public void CreateCredit(CreditModel credit)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_credits", con);
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.AddWithValue("@client_id", credit.clientId);
                cmd.Parameters.AddWithValue("@compte_id", credit.compteId);
                cmd.Parameters.AddWithValue("@montant", credit.montant);
                cmd.Parameters.AddWithValue("@duree", credit.duree);
                cmd.Parameters.AddWithValue("@taux_interet", credit.taux_interet);
                cmd.Parameters.AddWithValue("@statut", credit.statut);
                cmd.Parameters.AddWithValue("@relevespaie", credit.relevespaie);
                cmd.Parameters.AddWithValue("@datecredit", credit.datecredit);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void UpdateCredit(CreditModel credit)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_updatecredits", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", credit.clientId);
                cmd.Parameters.AddWithValue("@client_id", credit.clientId);
                cmd.Parameters.AddWithValue("@compte_id", credit.compteId);
                cmd.Parameters.AddWithValue("@montant", credit.duree);
                cmd.Parameters.AddWithValue("@taux_interet", credit.taux_interet);
                cmd.Parameters.AddWithValue("@statut", credit.statut);
                cmd.Parameters.AddWithValue("@relevespaie", credit.relevespaie);
                cmd.Parameters.AddWithValue("@datecredit", credit.datecredit);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void DeleteCredit(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var credit = new CreditModel();
                SqlCommand cmd = new SqlCommand("delete_credits", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", credit.CreditId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public CreditModel GetCreditById(int? Id)
        {
            var credit = new CreditModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetCreditById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", Id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                //cmd.ExecuteNonQuery();
                while (dr.Read())
                {
                    credit.CreditId = Convert.ToInt32(dr["id"].ToString());
                    credit.clientId = Convert.ToInt32(dr["client_id"].ToString());
                    credit.compteId = Convert.ToInt32(dr["compte_id"].ToString());
                    credit.montant = Convert.ToInt64(dr["montant"].ToString());
                    credit.duree = dr["duree"].ToString();
                    credit.taux_interet = Convert.ToInt64(dr["taux_interet"].ToString());
                    credit.statut = dr["statut"].ToString();
                    credit.relevespaie = dr["relevespaie"].ToString();
                    credit.datecredit = Convert.ToDateTime(dr["mail"].ToString());

                }
                con.Close();
            }
            return credit;

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

