<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Homepage.aspx.cs" Inherits="Homepage" %>

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
                <a id="profile1" href="Profilepage.aspx"><asp:Label ID="UsersName" runat="server" Text="Label"></asp:Label></a>
                <a id="home" href="Homepage.aspx">Home</a>
                <a id="findFriends" href="SuggestedFriendspage.aspx">Find Friends</a>
            </div>
        </div>

        <div class="userBar">
            <a id="profile2" href="Profilepage.aspx"><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></a>
            <p>Groups</p>
            <div id="groups">
                
                <a href="SuggestedSquadspage.apsx">+ Join a new Squad</a>
            </div>
        </div>

        <div class="createPost">
            <textarea ID="makeForumPost" runat="server" cols="20" rows="2" placeholder ="Hit the keys with force and vigor"></textarea>
            <asp:Button ID="postButton" runat="server" Text="Post" OnClick="postButton_Click1" />
        </div>"

        <div class="newsFeed">
             
        </div>

        


    </form>
</body>
</html>
