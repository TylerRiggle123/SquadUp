<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<html>
    <head>
        <title>SquadUp</title>
        <link rel="stylesheet" type="text/css" href="SquadStyles.css"" />
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
                </div>
            </div>

            <div class="userBar">
                <a id="profile2" href="UserProfile.aspx"><asp:Label ID="UserNameSideBar" runat="server" Text="Profile"></asp:Label></a>
                <p>Groups</p>
                    <div id="groups">
                
                    <a href="Squads.aspx">+ Join a new Squad</a>
                    </div>
            </div>

            <h1><asp:Label ID="UsersName" runat="server" Text=""></asp:Label></h1>

            <div class="editInformation">
                <asp:TextBox ID="EditEmail" runat="server"></asp:TextBox>
                <asp:Button ID="ConfirmEditEmail" runat="server" Text="Edit" onclick="ConfirmEditEmail_Click"/>

                <asp:TextBox ID="EditPassword" runat="server"></asp:TextBox>
                <asp:Button ID="ConfirmEditPassword" runat="server" Text="Edit" OnClick="ConfirmEditPassword_Click" />

                <asp:TextBox ID="EditLocation" runat="server"></asp:TextBox>
                <asp:Button ID="ConfirmEditLocation" runat="server" Text="Edit" OnClick ="ConfirmEditLocation_Click" />

                <asp:TextBox ID="EditPhoneNumber" runat="server"></asp:TextBox>
                <asp:Button ID="ConfirmEditPhoneNumber" runat="server" Text="Edit" OnClick ="ConfirmEditPhoneNumber_Click"/>
            </div>

            

        </form>
    </body>
</html>
