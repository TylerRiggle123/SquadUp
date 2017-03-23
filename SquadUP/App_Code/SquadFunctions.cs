using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;



public class SquadFunctions
{
    SqlConnection conn = new SqlConnection(@"Data Source=stusql;Initial Catalog=SquadDatabase; Integrated Security=true");

    public int GetUsersID(string sessionEmail)
    {
        if(conn != null && conn.State == System.Data.ConnectionState.Closed)
        conn.Open();

        int UsersID;
        string getID = "Select UserID from [User] where Email = '" + sessionEmail + "'; ";
        SqlCommand get = new SqlCommand(getID, conn);
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
    }

    public int[] GetFriendIDs(string sessionEmail)
    {
        int[] z = PopulateFriendsList(sessionEmail);
        string getFriendIDs = "Select FriendID from Friends where UserID = '" + GetUsersID(sessionEmail) + "';";
        SqlCommand getFriends = new SqlCommand(getFriendIDs, conn);
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
        return z;

    }

    public int[] PopulateFriendsList(string sessionEmail)
    {
        int[] friendsList;
        string getFriendIDs = "Select FriendID from Friends where UserID = '" + GetUsersID(sessionEmail) + "';";
        SqlCommand getFriends = new SqlCommand(getFriendIDs, conn);

        int x = 0;


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

    public string GetUsersName(string sessionEmail)
    {
        string userName;
        string fNameSQL = "Select FirstName from [User] where UserID=" + GetUsersID(sessionEmail) + ";";
        SqlCommand cmd1 = new SqlCommand(fNameSQL, conn);
        userName = cmd1.ExecuteScalar().ToString();


        string lNameSQL = "Select LastName from [User] where UserID=" + GetUsersID(sessionEmail) + ";";
        SqlCommand cmd2 = new SqlCommand(lNameSQL, conn);

        userName += cmd2.ExecuteScalar().ToString();

        return userName;
    }

    public void Create(string sqlCommand)
    {

        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlCommand, conn);
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


        }
    }

    public bool LogIn(string sqlCommand)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand(sqlCommand, conn);

        bool valid = false;
        try
        {
            string result;
            result = cmd.ExecuteScalar().ToString();
            int rowCount = Convert.ToInt32(result);

            if (rowCount >= 1)
            {
                valid = true;
                conn.Close();
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
            conn.Close();
        }

        return valid;
    }

}