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
    private int userID;

        

    

    protected void postButton_Click1(object sender, EventArgs e)
    {
        ArrayList idList = (ArrayList)Session["Squuuaaaddd"];
        string sessionUserEmail = idList[0].ToString();

        SqlConnection conn = new SqlConnection(@"Data Source=stusql;Initial Catalog=SquadDatabase; Integrated Security=true");
        string userPost = ((TextBox)makeForumPost.FindControl("makeForumPost")).Text;

        string registerSql = "Insert into ForumPosts values('"+ sessionUserEmail +"','"+ userPost + "',null)";

        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(registerSql, conn);
            cmd.ExecuteNonQuery();
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