<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Assignment_7.Pages.Login" %>
<%@ Register src="~/UserControls/LoginFormControl.ascx" tagname="LoginFormControl" tagprefix="loginPrefix" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Log In</h1>
    <loginPrefix:LoginFormControl ID="loginControl" runat="server" OnLoginClicked="loginControl_LoginClicked" />
</asp:Content>
