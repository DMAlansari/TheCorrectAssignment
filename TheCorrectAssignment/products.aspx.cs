using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheCorrectAssignment.Security;

namespace TheCorrectAssignment
{
    public partial class products : System.Web.UI.Page
    {
        BLL_GridView objectOfBLL_GridView = new BLL_GridView();
        protected void Page_Load(object sender, EventArgs e)
        {
            String encryptedCivil = Request.QueryString["encryptedCivil"];
            var key = "b14ca5898a4e4133bbce2ea2315a1916";
            var decrypted = DataProtection.DecryptString(key, encryptedCivil);
            getProducts(decrypted);


        }

        public void getProducts(String civilID)
        {

            if (civilID == null || civilID.Length == 0)
            {
                civilID = null;
            }


            DataTable dataTable = objectOfBLL_GridView.getClientData(civilID);
            foreach (DataRow row in dataTable.Rows) 
            {
                row["Civil_ID"] = row["Civil_ID"].ToString().Trim();
                row["Account_ID"] = row["Account_ID"].ToString().Trim();
                row["Balance"] = row["Balance"].ToString().Trim();
                row["Card_ID"] = row["Card_ID"].ToString().Trim();
                row["Card_Type_ID"] = row["Card_Type_ID"].ToString().Trim();

            }
            GridViewAccounts.DataSource = dataTable;
            GridViewAccounts.DataBind();
            GridViewCards.DataSource = dataTable;
            GridViewCards.DataBind();
        }

        protected void GridViewAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridViewAccounts_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}