using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class SearchResults : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(@"Data Source=stusql;Initial Catalog=SquadDatabase; Integrated Security=true");
    protected void Page_Load(object sender, EventArgs e)
    {
        string resultFName;
        string resultLName;
        conn.Open();
        string searchText;
        searchText = Session[1].ToString();+
        string fName = "Select FirstName from [User] where FirstName='"+searchText+"'";
        SqlCommand cmd1 = new SqlCommand(fName, conn);
        resultFName = cmd1.ExecuteScalar().ToString();
        string lName = "Select LastName from [User] where FirstName='"+ resultFName + "'";
        
        SqlCommand cmd2 = new SqlCommand(lName, conn);
        
        resultLName = cmd2.ExecuteScalar().ToString();
        Response.Write("<div class=\"newsFeed\">" + resultFName+" "+resultLName + "</div>");
    }
}