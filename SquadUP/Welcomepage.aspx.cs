using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class Welcomepage : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(@"Data Source=stusql;Initial Catalog=SquadDatabase; Integrated Security=true");
    protected void register_Click(object sender, EventArgs e)
    {
        
        string userEmail = ((TextBox)EmailRegistry.FindControl("EmailRegistry")).Text;
        string firstName = ((TextBox)FirstNameRegistry.FindControl("FirstNameRegistry")).Text;
        string lastName = ((TextBox)LastNameRegistry.FindControl("LastNameRegistry")).Text;
        string dateOfBirth = ((TextBox)DateOfBirth.FindControl("DateOfBirth")).Text;
        string password = ((TextBox)PasswordRegistry.FindControl("PasswordRegistry")).Text;
        string gender = ((DropDownList)GenderList.FindControl("GenderList")).Text;

        

        

        string registerSql = "insert into [User] values ('"+password+"','"+userEmail+"','"+firstName+"','"+lastName+"','"+gender+"','"+dateOfBirth+"',NULL,NULL)";

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

    protected void SignIn_Click(object sender, EventArgs e)
    {
        conn.Open();
        string userEmailLogIn = ((TextBox)emailLogin.FindControl("emailLogin")).Text;
        string passwordLogIn = ((TextBox)passwordLogin.FindControl("passwordLogin")).Text;

        bool valid = false;
        
        string loginSQL = "SELECT COUNT(Email) FROM [User] WHERE Email = '" + userEmailLogIn + "' AND Password = '" + passwordLogIn + "'";
        
        SqlCommand cmd = new SqlCommand(loginSQL, conn);
        try
        {
            string result;
            result = cmd.ExecuteScalar().ToString();
            int rowCount = Convert.ToInt32(result);

            if (rowCount >= 1)
            {
                valid = true;
                Response.Redirect("Homepage.aspx");
            }
            else if (rowCount <= 0)
            {
                valid = false;
                Response.Redirect("Welcomepage.aspx");
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

    }
}