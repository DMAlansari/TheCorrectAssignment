using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TheCorrectAssignment
{
    public class JoinedTables
    {
        public String civilID { get; set; }
        public int rimNumber { get; set; }
        public String name { get; set; }
        public String gender { get; set; }
        public String address { get; set; }
        public String phoneNumber { get; set; }
        public String profile { get; set; }
        public String accountNumber { get; set; }
        public int balance { get; set; }
        public String accountType { get; set; }
        public String cardNumber { get; set; }
        public String cardType { get; set; }

    }

    public class CustomerData
    {
        public static void updateClient(String civilID, int rimNumber, String name, String gender,
                                    String address, String phoneNumber, String profile, String accountNumber,
                                    int balance, String accountType, String cardNumber, String cardType)
        {

            SqlCommand command = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString))
            {
                connection.Open();
                command = new SqlCommand("dbo.Update_ClientInfo", connection);
                using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Civil_ID", civilID);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Phone_Number", phoneNumber);
                    command.Parameters.AddWithValue("@RIM_Number", rimNumber);

                    command.ExecuteNonQuery();

                }
            }
        }
        public static List<JoinedTables> getAllClients(String civilID)
        {
            List<JoinedTables> clientList = new List<JoinedTables>();
            SqlCommand command = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString))
            {

                command = new SqlCommand("dbo.Get_Client", connection);
                using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CivilID", civilID);
                    SqlDataReader reader = command.ExecuteReader();
                    connection.Open();
                    while (reader.Read())
                    {
                        JoinedTables clients = new JoinedTables();
                        clients.civilID = reader["Civil_ID"].ToString();
                        clients.rimNumber = Convert.ToInt16(reader["RIM_Number"]);
                        clients.name = reader["Name"].ToString();
                        clients.gender = reader["Gender"].ToString();
                        clients.address = reader["Address"].ToString();
                        clients.phoneNumber = reader["Phone_Number"].ToString();
                        clients.profile = reader["Type_ID"].ToString();
                        clients.accountNumber = reader["Account_ID"].ToString();
                        clients.balance = Convert.ToInt16(reader["Balance"]);
                        clients.accountType = reader["Account_Type"].ToString();
                        clients.cardNumber = reader["Card_ID"].ToString();
                        clients.cardType = reader["Card_Type_ID"].ToString();
                        clientList.Add(clients);
                    }


                }

                return clientList;
            }

        }

    }
    public class GetAndUpdateClient
    {
    }
}