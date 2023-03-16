using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using TheCorrectAssignment.Security;

namespace TheCorrectAssignment
{

    public partial class SiteMaster : MasterPage
    {
        BLL_GridView objectOfBLL_GridView = new BLL_GridView();
        DataProtection encrypt = new DataProtection();
     

        protected void Page_Load(object sender, EventArgs e)
        {
           // Grid view columns starts from zero
           GridViewMaster.Columns[8].Visible  = false;  // profile id
           GridViewMaster.Columns[9].Visible  = false;  // account number
           GridViewMaster.Columns[10].Visible = false;  // balance
           GridViewMaster.Columns[11].Visible = false;  // account type id
          // GridViewMaster.Columns[12].Visible = false;  // account type
           GridViewMaster.Columns[13].Visible = false;  // card number
           GridViewMaster.Columns[14].Visible = false;  // card type id
           GridViewMaster.Columns[15].Visible = false;  // card type
            if (!IsPostBack)
            {
              //  Response.Redirect("~/Site.Master");
              
            }
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
            foreach(DataRow row in dataTable.Rows) //DataRow
            {

                row["Civil_ID"] = row["Civil_ID"].ToString().Trim();
                row["RIM_Number"] = row["RIM_Number"].ToString().Trim();
                row["Name"] = row["Name"].ToString().Trim();
                row["Civil_ID"] = row["Civil_ID"].ToString().Trim();
                row["Gender"] = row["Gender"].ToString().Trim();
                row["Address"] = row["Address"].ToString().Trim();
                row["Phone_Number"] = row["Phone_Number"].ToString().Trim();
                row["Type_ID"] = row["Type_ID"].ToString().Trim();
                row["Account_ID"] = row["Account_ID"].ToString().Trim();
                row["Balance"] = row["Balance"].ToString().Trim();
                row["ID"] = row["ID"].ToString().Trim();
                row["Card_ID"] = row["Card_ID"].ToString().Trim();
                row["Card_Type_ID"] = row["Card_Type_ID"].ToString().Trim();
                
            }
            Session["clientTable"] = dataTable;
            GridViewMaster.DataSource = dataTable;
            GridViewMaster.DataBind();
            

        }

        public void newAccount()
        {
            Response.Redirect("New_client.aspx");
        }
        
        protected void new_clientBtn_Click(object sender, EventArgs e)
        {
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

      
        protected void buttons_Click(object sender, EventArgs e)
        {

        }



        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.
            GridViewMaster.EditIndex = e.NewEditIndex;
            getClient();
            getReference();
            DropDownList profileTypeDropDownList = GridViewMaster.Rows[e.NewEditIndex].FindControl("ProfileDropDownList") as DropDownList;
            DropDownList genderDropDownList = GridViewMaster.Rows[e.NewEditIndex].FindControl("GenderDropDownList") as DropDownList;
            DropDownList accountTypeDropDownList = GridViewMaster.Rows[e.NewEditIndex].FindControl("AccountDropDownList") as DropDownList;
            DataTable profileType = Session["profileType"] as DataTable;
            DataTable genderTable = Session["genderTable"] as DataTable;
            DataTable accountType = Session["accountType"] as DataTable;
            profileTypeDropDownList.DataSource = profileType;
            profileTypeDropDownList.DataBind();
            genderDropDownList.DataSource = genderTable;
            genderDropDownList.DataBind();
            accountTypeDropDownList.DataSource = accountType;
            accountTypeDropDownList.DataBind();


        }

        public void getReference()
        {
            DataTable profileType = new DataTable();
            DataTable genderTable = new DataTable();
            DataTable accountType = new DataTable();

            SqlCommand command = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString))
            {
                // Getting profile type reference
                connection.Open();
                command = new SqlCommand("dbo.GetProfileType", connection);
                using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    sqlData.Fill(profileType);
                    Session["profileType"] = profileType;
                }

                command = new SqlCommand("dbo.GetGender", connection);
                using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    sqlData.Fill(genderTable);
                    Session["genderTable"] = genderTable;
                }

                command = new SqlCommand("dbo.AccountType", connection);
                using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    sqlData.Fill(accountType);
                    Session["accountType"] = accountType;
                }

            }
        }

        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            TextBox civilID         = GridViewMaster.Rows[e.RowIndex].FindControl("CivilID") as TextBox;
            TextBox rimNumber       = GridViewMaster.Rows[e.RowIndex].FindControl("RIM_Number") as TextBox;
            TextBox name            = GridViewMaster.Rows[e.RowIndex].FindControl("Name") as TextBox;
            DropDownList genderList = GridViewMaster.Rows[e.RowIndex].FindControl("GenderDropDownList") as DropDownList;
            TextBox address         = GridViewMaster.Rows[e.RowIndex].FindControl("Address") as TextBox;
            TextBox phone_Number    = GridViewMaster.Rows[e.RowIndex].FindControl("PhoneNumber") as TextBox;
            DropDownList profileTypeDropDownList = GridViewMaster.Rows[e.RowIndex].FindControl("ProfileDropDownList") as DropDownList;
            DropDownList accountType = GridViewMaster.Rows[e.RowIndex].FindControl("AccountDropDownList") as DropDownList;
            Label   oldCivilID      = GridViewMaster.Rows[e.RowIndex].FindControl("lbl_OldCivilID") as Label; 
            Label   oldRIM_Number   = GridViewMaster.Rows[e.RowIndex].FindControl("lbl_OldRIM_Number") as Label; 
            TextBox accountNumber   = GridViewMaster.Rows[e.RowIndex].FindControl("AccountNumber") as TextBox;
            Label   balance         = GridViewMaster.Rows[e.RowIndex].FindControl("lbl_Balance") as Label;
            Label   cardID          = GridViewMaster.Rows[e.RowIndex].FindControl("lbl_CardID") as Label;
          //  Label   accountTypeID   = GridViewMaster.Rows[e.RowIndex].FindControl("lbl_AccountTypeID") as Label; 
            Label   cardTypeID      = GridViewMaster.Rows[e.RowIndex].FindControl("lbl_CardTypeID") as Label;

            // string better for casting 
            SqlCommand command = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString))
            {
                connection.Open();
                command = new SqlCommand("dbo.Update_ClientInfo", connection);
                using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CivilID", civilID.Text.ToString().Trim()); //nchar
                    command.Parameters.AddWithValue("@RIM_Number", Convert.ToInt32(rimNumber.Text.ToString().Trim())); //int
                    command.Parameters.AddWithValue("@Name", name.Text.ToString().Trim()); //nchar
                    command.Parameters.AddWithValue("@Gender", genderList.SelectedItem.ToString().Trim()); //nchar
                    command.Parameters.AddWithValue("@Address", address.Text.ToString().Trim()); //text
                    command.Parameters.AddWithValue("@Phone_Number", phone_Number.Text.ToString().Trim());
                    command.Parameters.AddWithValue("@ProfileTypeID", Convert.ToInt16(profileTypeDropDownList.SelectedValue.ToString().Trim())); //tinyint
                    command.Parameters.AddWithValue("@OldCivilID", oldCivilID.Text.ToString().Trim()); 
                    command.Parameters.AddWithValue("@OldRIM_Number", oldRIM_Number.Text.ToString().Trim()); 
                    command.Parameters.AddWithValue("@AccountID",accountNumber.Text.ToString().Trim());
                    command.Parameters.AddWithValue("@Balance", Convert.ToInt32(balance.Text.ToString().Trim())); //int
                    command.Parameters.AddWithValue("@AccountTypeID", Convert.ToInt16(accountType.SelectedValue.ToString().Trim())); // int
                    command.Parameters.AddWithValue("@CardID", cardID.Text.ToString().Trim());
                    command.Parameters.AddWithValue("@Card_Type_ID", Convert.ToInt16(cardTypeID.Text.ToString().Trim()));

                    command.ExecuteNonQuery();
                }
            }
            GridViewMaster.EditIndex = -1;
            getClient();
            getReference();
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
            // Response.Redirect(String.Format("~/Page2.aspx?name={0}&technology={1}", name, technology))

       
        }



        public void goToProducts(object sender, EventArgs e)
        {
                var key = "b14ca5898a4e4133bbce2ea2315a1916";
                var encryptedCivil = DataProtection.EncryptString(key, txtSearch.Text);
                Response.Redirect(String.Format("products.aspx?encryptedCivil={0}", encryptedCivil));
        }

        public String TrimTextBox(String txtbox)
        {
             return txtbox= txtbox.Trim();
        }

        public void getAccountNumber(String aString)
        {
             
        }

    

    }
}