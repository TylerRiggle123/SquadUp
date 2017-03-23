using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;

public partial class Welcomepage : System.Web.UI.Page
{
    SquadFunctions function = new SquadFunctions();
    SqlConnection conn = new SqlConnection(@"Data Source=stusql;Initial Catalog=SquadDatabase; Integrated Security=true");

    protected void register_Click(object sender, EventArgs e)
    {
        

        string userEmail = ((TextBox)EmailRegistry.FindControl("EmailRegistry")).Text;
        string firstName = ((TextBox)FirstNameRegistry.FindControl("FirstNameRegistry")).Text;
        string lastName = ((TextBox)LastNameRegistry.FindControl("LastNameRegistry")).Text;
        string dateOfBirth = ((TextBox)DateOfBirth.FindControl("DateOfBirth")).Text;
        string password = ((TextBox)PasswordRegistry.FindControl("PasswordRegistry")).Text;
        string gender = ((DropDownList)GenderList.FindControl("GenderList")).Text;
        Session["userEmail"]=userEmail;


        string registerSql = "insert into [User](Password, Email, FirstName, LastName, Gender, dateOfBirth) values ('"+password+"','"+userEmail+"','"+firstName+"','"+lastName+"','"+gender+"','"+dateOfBirth+"',NULL,NULL)";

        function.Create(registerSql);

    }

    protected void SignIn_Click(object sender, EventArgs e)
    {
        
        string userEmailLogIn = ((TextBox)emailLogin.FindControl("emailLogin")).Text;
        string passwordLogIn = ((TextBox)passwordLogin.FindControl("passwordLogin")).Text;

        
        Session["userEmail"] = userEmailLogIn;
        string loginSQL = "SELECT COUNT(Email) FROM [User] WHERE Email = '" + userEmailLogIn + "' AND Password = '" + passwordLogIn + "'";

        if (function.LogIn(loginSQL))
            Response.Redirect("Homepage.aspx");
        else
            Response.Redirect("Welcomepage.aspx");
        

    }
}