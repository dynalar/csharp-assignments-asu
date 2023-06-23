<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TryIt.aspx.cs" Inherits="Assignment_4.Question3.TryIt" %>

<asp:Content ID="Question3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Question 3</h3>
    <h5>This service converts Zip Codes to Latitude/Longitude boundaries</h5>
    <div>
        <asp:Label id="label2" AssociatedControlId="ZipCodeTextBox" Text="Zip Code:" runat="server" />
        <asp:TextBox ID="ZipCodeTextBox" runat="server" placeholder="Zip Code..."></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
    </div>
    <div class="box">
        <code>
            <asp:Literal ID="ResultLiteral" runat="server"></asp:Literal>
        </code>
    </div>
</asp:Content>