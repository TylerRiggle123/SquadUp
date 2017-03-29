using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class Squads : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(@"Data Source=stusql;Initial Catalog=SquadDatabase; Integrated Security=true");
    SquadFunctions function = new SquadFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void CreateSquad_Click(object sender, EventArgs e)
    {
        string squadName = ((TextBox)SquadName.FindControl("SquadName")).Text;
        string squadTag = ((TextBox)SquadTag.FindControl("SquadTag")).Text;
        string squadDescription = SquadDescription.Value;

        string createSquad = "insert into [Squads](SquadName, SquadTag, SquadDescription) values('" + squadName + "','" + squadTag + "','" + squadDescription + "';";

        function.Create(createSquad);

    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {

    }
}