<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Squads.aspx.cs" Inherits="Squads" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="squadNameCreate" runat="server"></asp:TextBox>
        <asp:DropDownList ID="squadTypeCreate" runat="server">
                        <asp:ListItem value="" selected="True">Squad Type</asp:ListItem>
                        <asp:ListItem Value="Squid"></asp:ListItem>
                        <asp:ListItem Value="Friends"></asp:ListItem>
                        <asp:ListItem Value="Coworkers"></asp:ListItem>
                        <asp:ListItem Value="Mother Russia"></asp:ListItem>
                        <asp:ListItem Value="Apache Helicopters"></asp:ListItem>
                        <asp:ListItem Value="Others"></asp:ListItem>
                        <asp:ListItem Value="Rainbow Fun Land"></asp:ListItem>
                        <asp:ListItem Value="Unicorn Mountain"></asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="createSquad" runat="server" Text="Create" OnClick="createSquad_Click" />
    </div>
    </form>
</body>
</html>
