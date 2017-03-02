<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Welcomepage.aspx.cs" Inherits="Welcomepage" %>

<html>
    <head>
        <title>Squad UP</title>
        <link href="SquadStyles.css" type="text/css" rel="stylesheet" />
    </head>

    <body>
        <form id="welcomPage" runat="server">
            <div class="header">
                <div class="headerImage">
                    <h1>Squad UP</h1>
                </div>

                <div id="loginForm">
                    <asp:TextBox ID="emailLogin" class="loginField" runat="server" placeholder="E-Mail"></asp:TextBox>  
                    <asp:TextBox ID="passwordLogin" class="loginField" runat="server" placeholder="Password"></asp:TextBox>
                    <asp:Button ID="login" runat="server" Text="Login" OnClick="SignIn_Click"/>
                </div>
            </div>

            <div class="section">
                <div id="welcomMessage">
                    <h3>"You'll Bounce Back"</h3>
                    <ul>
                        <li>Connect with old and new friends!</li>
                        <li>Get a squad together and post stupid memes!</li>
                        <li>Some third thing!</li>
                    </ul>
                </div>
                
                <div id="signUpForm">
                    <h1>Join Today, It's Free!</h1>
                    <asp:TextBox ID="FirstNameRegistry" runat ="server" placeholder="First name"></asp:TextBox>                    
                    <asp:TextBox ID="LastNameRegistry" runat="server" placeholder="Last name"></asp:TextBox> 
                    <asp:TextBox ID="EmailRegistry" runat="server" placeholder="E-Mail"></asp:TextBox>             
                    <asp:TextBox ID="PasswordRegistry" runat="server" placeholder="Password"></asp:TextBox>                
                    <asp:TextBox ID="DateOfBirth" runat="server" placeholder="MM/DD/YYYY"></asp:TextBox>
                    <asp:DropDownList ID="GenderList" runat="server">
                        <asp:ListItem value="" selected="True">Gender</asp:ListItem>
                        <asp:ListItem Value="Male"></asp:ListItem>
                        <asp:ListItem Value="Female"></asp:ListItem>
                        <asp:ListItem Value="Unicorn"></asp:ListItem>
                        <asp:ListItem Value="Other"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="signUp" runat="server" Text="Sign Up" OnClick="register_Click"/>
                </div>
            </div>
        </form>
    </body>


</html>
