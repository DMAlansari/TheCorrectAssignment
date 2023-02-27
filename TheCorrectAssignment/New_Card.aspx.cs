using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheCorrectAssignment
{
    public partial class New_Card : System.Web.UI.Page
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
                command = new SqlCommand("dbo.New_Card", connection);
                using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CardID", CardID.Text);
                    command.Parameters.AddWithValue("@Card_TypeID", Card_TypeID.Text);
                    command.Parameters.AddWithValue("@Civil_ID", Civil_ID.Text);
                    command.Parameters.AddWithValue("@Account_ID", Account_ID.Text);

                    
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