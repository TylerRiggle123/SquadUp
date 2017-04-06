using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SquadPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void logOutButton_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Hompage.aspx");
    }
}