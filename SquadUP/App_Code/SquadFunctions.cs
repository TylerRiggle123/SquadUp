using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Class1
/// </summary>
public class SquadFunctions
{
    public int GetUsersID(SqlConnection conn, string sessionEmail)
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
        finally
        {
            //conn.Close();
        }


    }
    
}