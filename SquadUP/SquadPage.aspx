<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SquadPage.aspx.cs" Inherits="SquadPage" %>


<html>
<head runat="server">
    <title>Squad UP</title>
    <link href="SquadStyles.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="searchNav">
            <asp:TextBox ID="SearchBar" runat="server" placeholder="Search..."></asp:TextBox>
            <asp:Button ID="SearchButton" runat="server" Text="Go" />
                <div id="navigation">
                <a id="profile1" href="UserProfile.aspx"><asp:Label ID="UsersNameNavBar" runat="server" Text="Profile"></asp:Label></a>
                <a id="home" href="Homepage.aspx">Home</a>
                <a id="findFriends" href="SuggestedFriendspage.aspx">Find Friends</a>
                <asp:Button ID="logOutButton" runat="server" Text="Log Out" OnClick="logOutButton_Click" />
            </div>
        </div>

        <div class="userBar">
            <a id="profile2" href="UserProfile.aspx"><asp:Label ID="UserNameSideBar" runat="server" Text="Profile"></asp:Label></a>
            <p>Groups</p>
                <div id="groups">
                    <a href="Squads.aspx">+ Join a new Squad</a>
                </div>
        </div>

        <div id="squadsName"><h1><asp:Label ID="SquadName" runat="server" Text="Name"></asp:Label></h1></div>

        <div id="squadsDescription"><h3><asp:Label ID="SquadDescription" runat="server" Text="Description"></asp:Label></h3></div>
    
    </form>
</body>
</html>
