using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using OctroitCredits.Models;

namespace OctroitCredits.Controllers
{
    public class Clients
    {
        string connectionString = "Data Source=PISCAS\\SA;Initial Catalog=CreditSoft;Integrated Security=True";

        public IEnumerable<ClientModel> GetAllClients()
        {
            var listClient = new List<ClientModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("fetchAallclient", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var client = new ClientModel();

                    client.Id = Convert.ToInt32(dr["id"].ToString());
                    client.Noms = dr["noms"].ToString();
                    client.Sexe = dr["sexe"].ToString();
                    client.Datenaiss = Convert.ToDateTime(dr["datenaiss"].ToString());
                    client.Adresse = dr["adresse"].ToString();
                    client.Etatcivil = dr["etatcivil"].ToString();
                    client.Telephone = dr["telephone"].ToString();
                    client.Mail = dr["mail"].ToString();
                    client.Profession = dr["profession"].ToString();
                    client.Adressepostal = dr["adressepostal"].ToString();
                    client.Nationalite = dr["nationalite"].ToString();

                    listClient.Add(client);
                }
                con.Close();
            }
            return listClient;
        }
        public void CreateClient(ClientModel clients)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_clients", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@noms", clients.Noms);
                cmd.Parameters.AddWithValue("@sexe", clients.Sexe);
                cmd.Parameters.AddWithValue("@datenaiss", clients.Datenaiss);
                cmd.Parameters.AddWithValue("@adresse", clients.Adresse);
                cmd.Parameters.AddWithValue("@etatcivil", clients.Etatcivil);
                cmd.Parameters.AddWithValue("@telephone", clients.Telephone);
                cmd.Parameters.AddWithValue("@mail", clients.Mail);
                cmd.Parameters.AddWithValue("@profession", clients.Profession);
                cmd.Parameters.AddWithValue("@adressepostal", clients.Adressepostal);
                cmd.Parameters.AddWithValue("@nationalite", clients.Nationalite);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateClient(ClientModel clients)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_updateclients", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", clients.Id);
                cmd.Parameters.AddWithValue("@noms", clients.Noms);
                cmd.Parameters.AddWithValue("@sexe", clients.Sexe);
                cmd.Parameters.AddWithValue("@datenaiss", clients.Datenaiss);
                cmd.Parameters.AddWithValue("@adresse", clients.Adresse);
                cmd.Parameters.AddWithValue("@etatcivil", clients.Etatcivil);
                cmd.Parameters.AddWithValue("@telephone", clients.Telephone);
                cmd.Parameters.AddWithValue("@mail", clients.Mail);
                cmd.Parameters.AddWithValue("@profession", clients.Profession);
                cmd.Parameters.AddWithValue("@adressepostal", clients.Adressepostal);
                cmd.Parameters.AddWithValue("@nationalite", clients.Nationalite);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteClient(int? Id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("delete_clients", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", Id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public ClientModel GetClientById(int? Id)
        {
            var client = new ClientModel();
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


                    client.Id = Convert.ToInt32(dr["id"].ToString());
                    client.Noms = dr["noms"].ToString();
                    client.Sexe = dr["sexe"].ToString();
                    client.Datenaiss = Convert.ToDateTime(dr["datenaiss"].ToString());
                    client.Adresse = dr["adresse"].ToString();
                    client.Etatcivil = dr["etatcivil"].ToString();
                    client.Telephone = dr["telephone"].ToString();
                    client.Mail = dr["mail"].ToString();
                    client.Profession = dr["profession"].ToString();
                    client.Adressepostal = dr["adressepostal"].ToString();
                    client.Nationalite = dr["nationalite"].ToString();

                }

                con.Close();
            }
            return client;
        }
    }
}

