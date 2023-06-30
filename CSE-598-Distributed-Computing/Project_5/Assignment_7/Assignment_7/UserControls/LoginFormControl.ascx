<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginFormControl.ascx.cs" Inherits="Assignment_7.UserControls.LoginFormControl" %>

<div>
    <div>
        <label for="usernameEntry">Username:</label>
        <asp:TextBox ID="usernameEntry" runat="server"></asp:TextBox>
    </div>
    <div>
        <label for="passwordEntry">Password:</label>
        <asp:TextBox ID="passwordEntry" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
    </div>
    <div>
        <asp:Label ID="errorMessageLabel" runat="server" ForeColor="Red"></asp:Label>
    </div>
</div>