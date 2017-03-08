using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;
public partial class Homepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        
    }
    private int userID;

        

    

    protected void postButton_Click1(object sender, EventArgs e)
    {

        string sessionUserEmail = Session[0].ToString();
        string findID = "Select UserID from [User] where Email ='" + sessionUserEmail + "'";
        SqlConnection conn = new SqlConnection(@"Data Source=stusql;Initial Catalog=SquadDatabase; Integrated Security=true");
        string userPost = makeForumPost.Value;

        string result;
        SqlCommand cmd = new SqlCommand(findID, conn);
        try
        {
            conn.Open();

            result = cmd.ExecuteScalar().ToString();
            int userID = Convert.ToInt32(result);
            string userPostSQL = "Insert into ForumPosts values('"+ userID+"','" + userPost + "',null)";
            SqlCommand cmd1 = new SqlCommand(userPostSQL, conn);
            cmd1.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Insert Error:";
            msg += ex.Message;
        }
        finally
        {
            conn.Close();
            Response.Redirect("Homepage.aspx");
        }
    }
}