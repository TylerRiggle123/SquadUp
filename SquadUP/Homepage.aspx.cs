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
    

    //Variable Declarations
    private static int[] FriendIDs;
    private bool AreTherePosts;
    private bool IsFriends;



    protected void Page_Load(object sender, EventArgs e)
    {
        string sessionEmail = Session[0].ToString();

        int UsersID = function.GetUsersID(sessionEmail);
        FriendIDs = function.GetFriendIDs(sessionEmail);

        UsersNameNavBar.Text = function.GetUsersName(sessionEmail);


    }

    protected void postButton_Click(object sender, EventArgs e)
    {
        int userID = function.GetUsersID(Session[0].ToString());
        

        if(makeForumPost.Value == null)
        {
            Response.Redirect("Homepage.aspx");
        }
        else
        {
            string textPost = makeForumPost.Value;
            string userPostSQL = "Insert into ForumPosts values('" + userID + "','" + textPost + "',null)";

            function.PostForum(userPostSQL);            

            Response.Redirect("Homepage.aspx");
        }
        


    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        Session["Search"] = SearchBar.Text;
        
        Response.Redirect("SearchResults.aspx");
        
    }

}