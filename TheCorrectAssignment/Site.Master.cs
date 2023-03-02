using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

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

        public Button SearchBtn
        {
            get
            {
                return this.btnSearch;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //  String result= "~/Default.aspx?result=" + txtSearch.Text;
            //   Response.Redirect(result);
            getClient();

        }

        public void getClient()
        {
            var civilID = txtSearch.Text;

            if (txtSearch.Text.Length == 0)
            {
                civilID = null;
            }
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



        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.  
            GridViewMaster.EditIndex = e.NewEditIndex;
            getClient();

        }

        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            
            TextBox CivilID = GridViewMaster.Rows[e.RowIndex].FindControl("CivilID") as TextBox;
            TextBox RIMNumber = GridViewMaster.Rows[e.RowIndex].FindControl("RIM_Number") as TextBox;
            TextBox Name = GridViewMaster.Rows[e.RowIndex].FindControl("Name") as TextBox;
            TextBox Gender = GridViewMaster.Rows[e.RowIndex].FindControl("Gender") as TextBox;
            TextBox Address = GridViewMaster.Rows[e.RowIndex].FindControl("Address") as TextBox;
            TextBox Phone_Number = GridViewMaster.Rows[e.RowIndex].FindControl("PhoneNumber") as TextBox;
            TextBox ProfileID = GridViewMaster.Rows[e.RowIndex].FindControl("ProfileID") as TextBox;
            TextBox AccountID = GridViewMaster.Rows[e.RowIndex].FindControl("AccountNumber") as TextBox;
            TextBox Balance = GridViewMaster.Rows[e.RowIndex].FindControl("Balance") as TextBox;
            TextBox AccountTypeID = GridViewMaster.Rows[e.RowIndex].FindControl("AccountTypeID") as TextBox;
            TextBox CardTypeID = GridViewMaster.Rows[e.RowIndex].FindControl("CardTypeID") as TextBox;
            TextBox CardID = GridViewMaster.Rows[e.RowIndex].FindControl("CardID") as TextBox;

            // string better for casting 
            SqlCommand command = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString))
            {
                connection.Open();
                command = new SqlCommand("dbo.Update_ClientInfo", connection);
                using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CivilID", CivilID.Text.ToString()); //nchar
                    command.Parameters.AddWithValue("@RIM_Number", Convert.ToInt32(RIMNumber.Text.ToString())); //int
                    command.Parameters.AddWithValue("@Name", Name.Text); //nchar
                    command.Parameters.AddWithValue("@Gender", Gender.Text); //nchar
                    command.Parameters.AddWithValue("@Address", Address.Text); //text
                    command.Parameters.AddWithValue("@Phone_Number", Phone_Number.Text);
                    command.Parameters.AddWithValue("@ProfileTypeID", Convert.ToInt16(ProfileID.Text.ToString())); //tinyint
                    command.Parameters.AddWithValue("@AccountID", AccountID.Text);
                    command.Parameters.AddWithValue("@Balance", Balance.Text);
                    command.Parameters.AddWithValue("@AccountTypeID", Convert.ToInt16(AccountTypeID.Text.ToString())); //tinyint
                    command.Parameters.AddWithValue("@CardTypeID", Convert.ToInt16(CardTypeID.Text.ToString())); //tinyint
                    command.Parameters.AddWithValue("@CardID", CardID.Text);
                    command.ExecuteNonQuery();
                    getClient();



                }



            }



        }

        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e) { 
        TextBox CivilID = GridViewMaster.Rows[e.RowIndex].FindControl("CivilID") as TextBox;
        SqlCommand command = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString))
            {
                connection.Open();
                command = new SqlCommand("dbo.Delete_Client", connection);
                using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CivilID", CivilID.Text.ToString());

                    // command.ExecuteNonQuery();
                    int success = command.ExecuteNonQuery();
                    if (success != 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Deleted!')", true);

                    }

                }
            }
            getClient();
        }
        protected void GridViewMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public String TrimTextBox(String txtbox)
        {
             return txtbox= txtbox.Trim();
        }
    }
}