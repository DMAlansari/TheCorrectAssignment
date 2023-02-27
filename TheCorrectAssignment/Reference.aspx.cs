using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace TheCorrectAssignment
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            get_ProfileType_Table();
            get_AccountType_Table();
            get_CardType_Table();
           

        }

        public void get_ProfileType_Table()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Profile_Type", connection);
                using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                {
                    sqlData.Fill(dataTable);
                    DataTable table = dataTable;
                    connection.Close();

                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();

                }
            }
        }

        public void get_AccountType_Table()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Account_Type", connection);
                using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                {
                    sqlData.Fill(dataTable);
                    DataTable table = dataTable;
                    connection.Close();

                    GridView2.DataSource = dataTable;
                    GridView2.DataBind();



                }
            }
        }

        public void get_CardType_Table()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Card_Type", connection);
                using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                {
                    sqlData.Fill(dataTable);
                    DataTable table = dataTable;
                    connection.Close();

                    GridView3.DataSource = dataTable;
                    GridView3.DataBind();



                }
            }
        }
    }
}