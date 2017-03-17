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
    private static int x;

    private static int[] FriendIDs;
   

    private bool AreTherePosts;
    private bool IsFriends;



    protected void Page_Load(object sender, EventArgs e)
    {       
        if (conn != null && conn.State == System.Data.ConnectionState.Closed)
        conn.Open();

        int UsersID = GetUsersID();
        FriendIDs = GetFriendIDs();
        //GetPosts();

        GetUsersName();

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

    //Grabs the current user's ID by using the Session[0].ToString()*Email used to log in* in a SQL query
    public int GetUsersID()
    {
        int UsersID;
        string getID = "Select UserID from [User] where Email = '" + Session[0].ToString() + "'; ";
        SqlCommand get = new SqlCommand(getID, conn);
        return UsersID = Convert.ToInt32(get.ExecuteScalar().ToString());
        
    }

    //Grabs the UserID for each corresponding friend that the initail users has 
    private int[] GetFriendIDs()
    {
        int[] z = PopulateFriendsList();
        string getFriendIDs = "Select FriendID from Friends where UserID = '" + GetUsersID() +"';";
        SqlCommand getFriends = new SqlCommand(getFriendIDs, conn);
        SqlDataReader reader = getFriends.ExecuteReader();

        
        using (reader)
        {
            while (reader.Read())
            {
                for(int i = 0; i < z.Length; i ++)
                {
                    z[i] = Convert.ToInt32(reader.GetValue(0).ToString());
                }
            }
            
        }
        reader.Close();
        return z;

    }
    
    //Populates the FriendsList
    private int[] PopulateFriendsList()
    {
        int[] friendsList;
        string getFriendIDs = "Select FriendID from Friends where UserID = '" + squadMainClass.GetUsersID(conn, Session[0].ToString()) + "';";
        SqlCommand getFriends = new SqlCommand(getFriendIDs, conn);

        x = 0;


        using (SqlDataReader rdr = getFriends.ExecuteReader())
        {
            while (rdr.Read())
            {
               x++;
            }
            rdr.Close();
        }
        
       return friendsList = new int[x];
    }

    //Changed the names of labes to the user's first and last name
    private void GetUsersName()
    {
        string userFName;
        string fNameSQL = "Select FirstName from [User] where UserID=" + GetUsersID() + ";";
        SqlCommand cmd1 = new SqlCommand(fNameSQL, conn);
        userFName = cmd1.ExecuteScalar().ToString();


        string userLName;
        string lNameSQL = "Select LastName from [User] where UserID=" + GetUsersID() + ";";
        SqlCommand cmd2 = new SqlCommand(lNameSQL, conn);

        userLName = cmd2.ExecuteScalar().ToString();



        UsersNameNavBar.Text = userFName + " " + userLName;
        UserNameSideBar.Text = userFName + " " + userLName;
    }
}