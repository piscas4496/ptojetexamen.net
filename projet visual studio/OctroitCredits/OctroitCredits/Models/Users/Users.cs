using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OctroitCredits.Models;
using System.Data;

namespace OctroitCredits.Controllers
{
    public class Users
    {
        readonly string connectionString = "Data Source=PISCAS\\SA;Initial Catalog=CreditSoft;Integrated Security=True";

        public IEnumerable<UsersModel> GetAllUsers()
        {
            var listUsers = new List<UsersModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllUsers", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var users = new UsersModel();

                    users.Id = Convert.ToInt32(dr["id"].ToString());
                    users.Noms = dr["noms"].ToString();
                    users.Email = dr["email"].ToString();
                    users.Password = dr["password"].ToString();
                    users.Roles = dr["roles"].ToString();

                    listUsers.Add(users);
                }
                con.Close();
            }
            return listUsers;
        }
        public void CreateUsers(UsersModel users)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_users", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@noms", users.Noms);
                cmd.Parameters.AddWithValue("@email", users.Email);
                cmd.Parameters.AddWithValue("@password", users.Password);
                cmd.Parameters.AddWithValue("@roles", users.Roles);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateUsers(UsersModel users)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_updateusers", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", users.Id);
                cmd.Parameters.AddWithValue("@noms", users.Noms);
                cmd.Parameters.AddWithValue("@email", users.Email);
                cmd.Parameters.AddWithValue("@password", users.Password);
                cmd.Parameters.AddWithValue("@roles", users.Roles);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteUsers(int? Id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("deleteUsers", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", Id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public UsersModel GetUsersById(int? Id)
        {
            var users = new UsersModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetUserById", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", Id);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    users.Id = Convert.ToInt32(dr["id"].ToString());
                    users.Noms = dr["noms"].ToString();
                    users.Email = dr["email"].ToString();
                    users.Password = dr["password"].ToString();
                    users.Roles = dr["roles"].ToString();
                }

                con.Close();
            }
            return users;
        }
        public int LoginCheck(UsersModel ad)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand com = new SqlCommand("pro_Login", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@email", ad.Email);
            com.Parameters.AddWithValue("@password", ad.Password);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@isvalid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            com.Parameters.Add(oblogin);
            con.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            con.Close();
            return res;

        }
    }

    

}

