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
    SquadFunctions function = new SquadFunctions();
    SqlConnection conn = new SqlConnection(@"Data Source=stusql;Initial Catalog=SquadDatabase; Integrated Security=true");

    //Variable Declarations
    private static int[] FriendIDs;
    private bool AreTherePosts;
    private bool IsFriends;



    protected void Page_Load(object sender, EventArgs e)
    {       
        if (conn != null && conn.State == System.Data.ConnectionState.Closed)
        conn.Open();
        string sessionEmail = Session[0].ToString();

        int UsersID = function.GetUsersID(sessionEmail);
        FriendIDs = function.GetFriendIDs(sessionEmail);
        //GetPosts();

        UsersNameNavBar.Text = function.GetUsersName(sessionEmail);

        conn.Close();
        
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
            if (makeForumPost == null)
            {
                Response.Redirect("Homepage.aspx");

            }
            else
            {
                int userID = Convert.ToInt32(result);
                string userPostSQL = "Insert into ForumPosts values('" + userID + "','" + userPost + "',null)";
                SqlCommand cmd1 = new SqlCommand(userPostSQL, conn);
                cmd1.ExecuteNonQuery();
            }
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

    private void GetPosts()
    {
        string posts;
        posts = "<div class=\"newsFeed\">";
        for (int i = 0; i < FriendIDs.Length; i ++)
        {
            
            string getPosts = "Select Post from ForumPosts where UserID = '" + FriendIDs[i] + "';";
            SqlCommand get = new SqlCommand(getPosts, conn);
            
            SqlDataReader reader = get.ExecuteReader();
            
                while (reader.Read())
                {
                    posts += reader.GetValue(0).ToString() + "<br>";
                }
                posts += "</div>";
            
        }
        Response.Write(posts);
        
        
    }

}