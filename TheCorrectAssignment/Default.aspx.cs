using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Policy;

namespace TheCorrectAssignment
{
    public partial class _Default : Page
    {
        BLL_GridView objectOfBLL_GridView = new BLL_GridView();
        
        protected void Page_Load(object sender, EventArgs e)
        {

          //  testing.Attributes.Add("Style", "background-color:black");

        }

        //public void bindData()
        //{
        //    DataTable dataTable = objectOfBLL_GridView.getClientData();
        //    GridView1.DataSource= dataTable;
        //    GridView1.DataBind();
        //}

        protected void searchButton_Click(object sender, EventArgs e)
        {
           // var connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

            //using(var sqlConnection = new SqlConnection(connectionString))
            //{
            //    //sqlConnection.Open();
            //    //using (var sqlCommand = new SqlCommand("EXEC [dbo].[Get_Client] @CivilID = '293013101187'", sqlConnection)) ;
            //    //{
            //    //    // it is more efficiant to use parameter and a variable that contains the query instead of using it directly
            //    //    //  SqlCommand.Parameters.AddWithValue("CivilID", TextBox2.Text);
            //    //    // execute non query means no return table 
            //    //}

            //    SqlCommand command = sqlConnection.CreateCommand();
            //    command.CommandType = System.Data.CommandType.StoredProcedure;
            //    command.CommandText = "EXEC [dbo].[Get_Client] @CivilID = '293013101187'";
            //    SqlDataAdapter sqlData = new SqlDataAdapter(command);
            //    DataTable sqlTable = new DataTable();
            //    sqlData.Fill(sqlTable);

            //  //  return sqlTable; // this should be in a method?

            //    GridView1.DataSource= sqlTable;
            //    GridView1.DataBind();


           // }
        
        }

  

     
     

     
    }
}