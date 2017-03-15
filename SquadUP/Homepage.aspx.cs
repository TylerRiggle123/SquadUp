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
    SquadFunctions squadMainClass = new SquadFunctions();
    SqlConnection conn = new SqlConnection(@"Data Source=stusql;Initial Catalog=SquadDatabase; Integrated Security=true");

    //Variable Declarations 
    private static int[] FriendIDs;

    private bool AreTherePosts;
    private bool IsFriends;



    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Closed)
            conn.Open();
        int UsersID = squadMainClass.GetUsersID(conn,Session[0].ToString());
        //int[] FriendIDs = GetFriendIDs();
        string userFName;
        string fNameSQL = "Select FirstName from [User] where UserID='" + UsersID + "'";
        SqlCommand cmd1 = new SqlCommand(fNameSQL, conn);
        userFName = cmd1.ExecuteScalar().ToString();


        string userLName;
        string lNameSQL = "Select LastName from [User] where UserID='" + UsersID + "'";
        SqlCommand cmd2 = new SqlCommand(lNameSQL, conn);
        
        userLName = cmd2.ExecuteScalar().ToString();
        


        UsersName.Text = userFName+" "+userLName;
        UserNameSideBar.Text = userFName + " " + userLName;
        conn.Close();
        }
        catch (SqlException ex)
        {
            string msg = "Insert Error:";
            msg += ex.Message;

        }
    }

    protected void postButton_Click1(object sender, EventArgs e)
    {

        string sessionUserEmail = Session[0].ToString();
        string findID = "Select UserID from [User] where Email ='" + sessionUserEmail + "'";
        
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

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        Session["Search"] = SearchBar.Text;
        
        Response.Redirect("SearchResults.aspx");
        
    }

    private void GetPost()
    {

    }

    //Grabs the current user's ID by using the Session[0].ToString()/*Email used to log in*/ in a SQL query
    

    /*private int[] GetFriendIDs()
    {
        int[] friendIDs;
        int count = 0;
        string getFriendIDs = "Select FriendID from Friends where UserID = '" + squadMainClass.GetUsersID(conn,Session[0].ToString()) +"';";
        SqlCommand getFriends = new SqlCommand(getFriendIDs, conn);
        using (SqlDataReader rdr = getFriends.ExecuteReader())
        {
            while (rdr.Read())
            {
                count++;
            }
            
        }
        friendIDs = new int[count];
        count = 0;
        using (SqlDataReader rdr = getFriends.ExecuteReader())
        {
            while(rdr.Read())
            {
                friendIDs[count] = 
                count++;
            }
        }
        return friendIDs;
    }*/
}