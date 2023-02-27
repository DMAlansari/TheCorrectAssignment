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
    public partial class New_Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitNewClient_Click(object sender, EventArgs e)
        {
            SqlCommand command = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString))
            {
                connection.Open();
                command = new SqlCommand("dbo.New_Account", connection);
                using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Account_ID", Account_ID.Text);
                    command.Parameters.AddWithValue("@Account_Type", Account_Type.Text);
                    command.Parameters.AddWithValue("@Balance", Balance.Text);
                    command.Parameters.AddWithValue("@Civil_ID", Civil_ID.Text);
                   
                    // command.ExecuteNonQuery();
                    int success = command.ExecuteNonQuery();
                    if (success != 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Successful!')", true);

                    }
                    


                }
            }
        }
    }
}