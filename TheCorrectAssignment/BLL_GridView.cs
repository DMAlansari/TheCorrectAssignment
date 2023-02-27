using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace TheCorrectAssignment
{
    public class BLL_GridView
    {


        public DataTable getClientData(String civilID)
        {


            DataTable dataTable = new DataTable();
            SqlCommand command = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString))
            {
                connection.Open();
                command = new SqlCommand("dbo.Get_Client", connection);
                using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CivilID", civilID);
                    sqlData.Fill(dataTable);
                    DataTable table = dataTable;
                    connection.Close();
                    return table;

                }
            }

   
            // -------------------- Rahaf's Code
            //DataTable table = new DataTable();
            //using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString))
            //using (var cmd = new SqlCommand("dbo.Get_Client", con))
            //using (var da = new SqlDataAdapter(cmd))
            //{
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@CivilID", civilID);
            //    da.Fill(table);
            //    DataTable x = table;
            //    return x;
            //}


        }

        }
    }
