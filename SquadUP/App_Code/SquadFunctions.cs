
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


public class SquadFunctions
{
    SqlConnection con = new SqlConnection(@"Data Source=stusql;Initial Catalog=SquadDatabase; Integrated Security=true");

    // obtains and returns the User's ID
    public int GetUsersID(string sessionEmail)
    {
        con.Open();
        int UsersID;
        string getID = "Select UserID from [User] where Email = '" + sessionEmail + "'; ";
        SqlCommand get = new SqlCommand(getID, con);
        try
        { 
            return UsersID = Convert.ToInt32(get.ExecuteScalar().ToString());
        }
        catch(SqlException ex)
        {
            string msg = "Insert Error:";
            msg += ex.Message;
            return 0;
        }
        finally
        {
            con.Close();
        }
        
    }

    // obtains and returns  an array of ID's owned by the User's Friends 
    public int[] GetFriendIDs(string sessionEmail)
    {
        
        int[] z = PopulateFriendsList(sessionEmail);
        string getFriendIDs = "Select FriendID from Friends where UserID = '" + GetUsersID(sessionEmail) + "';";
        con.Open();
        SqlCommand getFriends = new SqlCommand(getFriendIDs, con);
        SqlDataReader reader = getFriends.ExecuteReader();


        using (reader)
        {
            while (reader.Read())
            {
                for (int i = 0; i < z.Length; i++)
                {
                    z[i] = Convert.ToInt32(reader.GetValue(0).ToString());
                }
            }

        }
        reader.Close();
        con.Close();
        return z;
        

    }

    // populates and returns an array with the length required to store the User's friend ID's 
    public int[] PopulateFriendsList(string sessionEmail)
    {
        
        int[] friendsList;
        string getFriendIDs = "Select FriendID from Friends where UserID = '" + GetUsersID(sessionEmail) + "';";
        SqlCommand getFriends = new SqlCommand(getFriendIDs, con);

        int x = 0;

        con.Open();
        using (SqlDataReader rdr = getFriends.ExecuteReader())
        {
            while (rdr.Read())
            {
                x++;
            }
            rdr.Close();
        }
        con.Close();
        
        return friendsList = new int[x];
    }

    // obtains and returns a string variable with the Users First and Last Name
    public string GetUsersName(string sessionEmail)
    {
        
        string userName;
        string fNameSQL = "Select FirstName from [User] where UserID=" + GetUsersID(sessionEmail) + ";";
        con.Open();
        SqlCommand cmd1 = new SqlCommand(fNameSQL, con);
        userName = cmd1.ExecuteScalar().ToString();
        con.Close();

        string lNameSQL = "Select LastName from [User] where UserID=" + GetUsersID(sessionEmail) + ";";
        SqlCommand cmd2 = new SqlCommand(lNameSQL, con);
        con.Open();
        userName += cmd2.ExecuteScalar().ToString();
        con.Close();

        return userName;
    }

    // executes an insert SQL command passed through a string variable 
    public void Create(string sqlCommand)
    {
        con.Open();
        try
        {         
            SqlCommand cmd = new SqlCommand(sqlCommand, con);
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Insert Error:";
            msg += ex.Message;
        }
        finally
        {
            con.Close();
        }
    }

    // returns a boolean value based on a sql command
    public bool LogIn(string sqlCommand)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand(sqlCommand, con);

        bool valid = false;
        try
        {
            string result;
            result = cmd.ExecuteScalar().ToString();
            int rowCount = Convert.ToInt32(result);

            if (rowCount >= 1)
            {
                valid = true;
                con.Close();
            }
            else if (rowCount <= 0)
            {
                valid = false;
            }
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Insert Error:";
            msg += ex.Message;
        }
        finally
        {
            con.Close();
        }

        return valid;
    }
    
    // executes an insert SQL command passed through a string variable
    public void PostForum(string sqlCommand)
    { 
        SqlCommand cmd = new SqlCommand(sqlCommand, con);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    /*public string[] GetPosts(string sqlCommand)
    {
        string[] posts = new string[1];
        string[] reserve1;

        SqlCommand getPosts = new SqlCommand(sqlCommand, con);
        SqlDataReader reader = getPosts.ExecuteReader();
        using (reader)
        {
            while (reader.Read())
            {
               for(int i = 0; i < posts.Length; i++)
                {
                    if(reader.get)
                }

            }

        }

        return posts;

    }*/



}