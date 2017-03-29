using System;
using System.Data.SqlClient;
public partial class UserProfile : System.Web.UI.Page
{
    
    SqlConnection conn = new SqlConnection(@"Data Source=stusql;Initial Catalog=SquadDatabase; Integrated Security=true");
    SquadFunctions squadMainClass = new SquadFunctions();

    int x;

    protected void Page_Load(object sender, EventArgs e)
    {
        string sessionEmail = Session[0].ToString();
        UsersNameNavBar.Text = squadMainClass.GetUsersName(sessionEmail);
        UserNameSideBar.Text = squadMainClass.GetUsersName(sessionEmail);
        conn.Open();
        int userID;
        
        userID = GetUsersID();


        //string[] Friends = GetUsersFriends();

        GetUserFeed();
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
                Response.Redirect("UserProfile.aspx");

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
            Response.Redirect("UserProfile.aspx");
        }
    }

    //Grabs the current user's ID by using the Session[0].ToString()*Email used to log in* in a SQL query
    private int GetUsersID()
    {
        
        int UsersID;
        string getID = "Select UserID from [User] where Email = '" + Session[0].ToString() + "'; ";
        SqlCommand get = new SqlCommand(getID, conn);
        return UsersID = Convert.ToInt32(get.ExecuteScalar().ToString());
        
    }

    //Grabs the UserID for each corresponding friend that the initail users has 
    private int[] GetFriendIDs()
    {
        int[] z = new int[PopulateFriendsList()];
        string getFriendIDs = "Select FriendID from Friends where UserID = '" + GetUsersID() + "';";
        
        SqlCommand getFriends = new SqlCommand(getFriendIDs, conn);
        SqlDataReader reader = getFriends.ExecuteReader();
        



        using (reader)
        {
            while (reader.Read())
            {
                int x;   
                int y=0;
                y++;
                x=Convert.ToInt16(reader.GetValue(0).ToString());
                z[y] = x;
                reader.NextResult();

            }

        }
       
        return z;

    }

    //Populates the FriendsList
    private int PopulateFriendsList()
    {
        
        string getFriendIDs = "Select FriendID from Friends where UserID = '" + GetUsersID() + "';";
        SqlCommand getFriends = new SqlCommand(getFriendIDs, conn);

        x = 0;


        using (SqlDataReader rdr = getFriends.ExecuteReader())
        {
            while (rdr.Read())
            {
                x++;
            }
        }
        return x;
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

    //populates a string array 
    /*private string[] GetUsersFriends()
    {
        

        string[] friendNames = new string[PopulateFriendsList()];
        int[] friendid = GetFriendIDs();

        for(int i = 0; i < friendid.Length; i++)
        {
            string getFriendNames = "Select FirstName from [User] where UserID = " + friendid[i] + ";";
            
            SqlCommand get = new SqlCommand(getFriendNames, conn);
            friendNames[i] = get.ExecuteScalar().ToString();
            
                   
            
        }

        return friendNames;
    }*/
    

    private void GetUserFeed()
    {
        string getPostSQL;
        getPostSQL = "Select Post from ForumPosts where UserID=" + GetUsersID();

        SqlCommand cmd = new SqlCommand(getPostSQL, conn);

        SqlDataReader result = cmd.ExecuteReader();
        string sendBack;
        sendBack = "<div class=\"userFeed\">";
        while (result.Read())
        {
            sendBack += "<div class =\"story\" > " + result.GetValue(0).ToString() + "</div>";

        }
        sendBack += "</div>";
        Response.Write(sendBack);
    }

    protected void ConfirmEditEmail_Click(object sender, EventArgs e)
    {
        conn.Open();
        string get = "Update [User] set Email = '" +  EditEmail.Text + "' where UserID = " + GetUsersID() + ";";
        SqlCommand command = new SqlCommand(get, conn);
        command.ExecuteNonQuery();
        conn.Close();
    }

    protected void ConfirmEditPassword_Click(object sender, EventArgs e)
    {
        conn.Open();
        string get = "Update [User] set Password = '" + EditPassword.Text + "' where UserID = " + GetUsersID() + ";";
        SqlCommand command = new SqlCommand(get, conn);
        command.ExecuteNonQuery();
        conn.Close();
    }

    protected void ConfirmEditLocation_Click(object sender, EventArgs e)
    {
        conn.Open();
        string get = "Update [User] set Location = '" + EditLocation.Text + "' where UserID = " + GetUsersID() + ";";
        SqlCommand command = new SqlCommand(get, conn);
        command.ExecuteNonQuery();
        conn.Close();
    }

    protected void ConfirmEditPhoneNumber_Click(object sender, EventArgs e)
    {
        conn.Open();
        string get = "Update [User] set PhoneNumber = '" + EditPhoneNumber.Text + "' where UserID = " + GetUsersID() + ";";
        SqlCommand command = new SqlCommand(get, conn);
        command.ExecuteNonQuery();
        conn.Close();
    }
}