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

                </div>

                <div id="loginForm">
                    <p>Email</p>
                    <asp:TextBox ID="emailLogin" runat="server"></asp:TextBox>
                    <p>Password</p>
                    <asp:TextBox ID="passwordLogin" runat="server"></asp:TextBox>
                    <asp:Button ID="SignIn" runat="server" Text="Sign-In" OnClick="SignIn_Click" />
                </div>
                
            </div>

            <div class="section">
                <div id="welcomMessage">
                    <p> BOX</p>
                </div>
                
                <div id="signUpForm">
                    Email
                    <asp:TextBox ID="EmailRegistry" runat="server"></asp:TextBox>
                    <br />
                    First Name
                    <asp:TextBox ID="FirstNameRegistry" runat ="server"></asp:TextBox>
                    <br />
                    Last Name
                    <asp:TextBox ID="LastNameRegistry" runat="server"></asp:TextBox>
                    <br />
                    Date of birth 
                    <asp:TextBox ID="DateOfBirth" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Password
                    <asp:TextBox ID="PasswordRegistry" runat="server"></asp:TextBox>
                    <br />
                    Confirm Password 
                    <asp:TextBox ID="ConfirmPasswordRegistry" runat="server"></asp:TextBox>
                    <br />
                    Gender
                    <asp:DropDownList ID="GenderList" runat="server">
                        
                    <asp:ListItem value="male" selected="False">
                        Male
                    </asp:ListItem>
                    <asp:ListItem value="female" selected="False">
                        Female
                    </asp:ListItem>
                        <asp:ListItem value="Unicorn" selected="False">
                        Unicorn
                    </asp:ListItem>
                        <asp:ListItem value="Other" selected="False">
                        Other
                    </asp:ListItem>
                    </asp:DropDownList>

                    <asp:Button ID="register" runat="server" Text="Register" OnClick="register_Click" />

                </div>
            </div>
        </form>
    </body>


</html>
