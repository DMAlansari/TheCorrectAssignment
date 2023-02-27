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
    public partial class WebForm1 : System.Web.UI.Page
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
                command = new SqlCommand("dbo.New_Client", connection);
                using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CivilID", CivilID.Text);
                    command.Parameters.AddWithValue("@RIM_Number", RIM_Number.Text);
                    command.Parameters.AddWithValue("@Name", Name.Text);
                    command.Parameters.AddWithValue("@Gender", Gender.Text);
                    command.Parameters.AddWithValue("@Address", Address.Text);
                    command.Parameters.AddWithValue("@Phone_Number", Phone_Number.Text);
                    command.Parameters.AddWithValue("@Type_ID", Type_ID.Text);
                    command.Parameters.AddWithValue("@Account_ID", Account_ID.Text);
                    command.Parameters.AddWithValue("@Account_Type", Account_Type.Text);
                    command.Parameters.AddWithValue("@Balance", Balance.Text);
                    command.Parameters.AddWithValue("@Card_ID", Card_ID.Text);
                    command.Parameters.AddWithValue("@Card_Type", Card_Type.Text);
                   // command.ExecuteNonQuery();
                    int success = command.ExecuteNonQuery();
                    if (success != 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Successful!')", true);

                    }
                    connection.Close();
                    

                }
            }
        }

       

       
    }
}