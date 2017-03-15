using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class UserProfile : System.Web.UI.Page
{
    
    SqlConnection conn = new SqlConnection(@"Data Source=stusql;Initial Catalog=SquadDatabase; Integrated Security=true");
    SquadFunctions squadMainClass = new SquadFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        int userID;
        userID = squadMainClass.GetUsersID(conn,Session[0].ToString());
        string getPostSQL;
        getPostSQL = "Select Post from ForumPosts where UserID="+userID;
        SqlCommand cmd = new SqlCommand(getPostSQL, conn);

        SqlDataReader result = cmd.ExecuteReader();
        while(result.Read())
        {
            Response.Write("<div class=\"userFeed\">"+result.GetValue(0).ToString());

        }
        
    }
}