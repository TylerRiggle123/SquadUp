<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Squads.aspx.cs" Inherits="Squads" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Squad Up</title>
    <link href="SquadStyles.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="searchNav">
            <asp:TextBox ID="SearchBar" runat="server" placeholder="Search..."></asp:TextBox>
            <asp:Button ID="SearchButton" runat="server" Text="Go" OnClick="SearchButton_Click" />
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

        <div id="Squad Message">
            <p>
                Squads are a nifty way the you can your friends can post to eachother directly! all you have to do is create one now and have your friends join!
            </p>
        </div>

        <div id="createSquad">
            <asp:TextBox ID="SquadName" runat="server"></asp:TextBox>
            <asp:TextBox ID="SquadTag" runat="server"></asp:TextBox>
            <textarea id="SquadDescription" runat="server" cols="20" rows="2"></textarea>
            <asp:Button ID="CreateSquad" runat="server" Text="Create" OnClick="CreateSquad_Click"/>
        </div>
    </form>
</body>
</html>
