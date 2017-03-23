using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class Squads : System.Web.UI.Page
{
    static string squadName;
    static string squadType;
    SqlConnection conn = new SqlConnection(@"Data Source=stusql;Initial Catalog=SquadDatabase; Integrated Security=true");
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void createSquad_Click(object sender, EventArgs e)
    {
        squadName= ((TextBox)squadNameCreate.FindControl("squadNameCreate")).Text;
        squadType = ((DropDownList)squadTypeCreate.FindControl("squadTypeCreate")).Text;
        string createSquadSql = "insert into Squads values ('" + squadName + "','" + squadType + "');";

        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(createSquadSql, conn);
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
            Response.Redirect("Squads.aspx");
        }
    }

    protected void changeSquadNameButton_Click(object sender, EventArgs e)
    {
        conn.Open();
        string get = "Update Squads set SquadName = '" + squadNameChange.Text + "' where SquadName = " + squadName + ";";
        squadName = squadNameChange.Text;
        SqlCommand command = new SqlCommand(get, conn);
        command.ExecuteNonQuery();
        conn.Close();
    }

    protected void squadTypeChangeButton_Click(object sender, EventArgs e)
    {
        conn.Open();
        string get = "Update Squads set SquadType = '" + squadTypeChange.Text + "' where SquadName = " + squadName + ";";
        
        SqlCommand command = new SqlCommand(get, conn);
        command.ExecuteNonQuery();
        conn.Close();
    }
}