using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheCorrectAssignment
{
    public partial class SiteMaster : MasterPage
    {
        BLL_GridView objectOfBLL_GridView = new BLL_GridView();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

 


        public String searchByCivilID
        {
            get
            {
                return this.txtSearch.Text;
            }
        }

        public Button SearchBtn { 
            get 
            {
                return this.btnSearch; 
            } 
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //  String result= "~/Default.aspx?result=" + txtSearch.Text;
            //   Response.Redirect(result);

            var civilID = txtSearch.Text;
            DataTable dataTable = objectOfBLL_GridView.getClientData(civilID);
            GridViewMaster.DataSource = dataTable;
            GridViewMaster.DataBind();
        }
   
        public void newAccount()
        {
            Response.Redirect("New_client.aspx");
        }
        protected void delete_btm_Click(object sender, EventArgs e)
        {
            SqlCommand command = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString))
            {
                connection.Open();
                command = new SqlCommand("dbo.Delete_Client", connection);
                using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CivilID", txtSearch.Text);
    
                    // command.ExecuteNonQuery();
                    int success = command.ExecuteNonQuery();
                    if (success != 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Successful!')", true);

                    }



                }
            }

        }
        protected void new_clientBtn_Click(object sender, EventArgs e)
        {
            // delete from database
             Response.Redirect("new_client.aspx");

        }

        
             protected void new_AccountBtn_Click(object sender, EventArgs e)
        {
         
            Response.Redirect("New_Account.aspx");

        }

        protected void new_CardBtn_Click(object sender, EventArgs e)
        {

            Response.Redirect("New_Card.aspx");

        }

        protected void update_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("update_client.aspx");
        }

        protected void buttons_Click(object sender, EventArgs e)
        {

        }

     
    }
}