<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Assignment_7.Pages.Signup" %>
<%@ Register src="~/UserControls/SignupFormControl.ascx" tagname="SignupFormControl" tagprefix="signupPrefix" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Sign Up</h1>
   <signupPrefix:SignupFormControl ID="signupControl" runat="server" OnLoginClicked="signupControl_SignupClicked" />
</asp:Content>
