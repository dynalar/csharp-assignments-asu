<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TryIt.aspx.cs" Inherits="Assignment_4_5.WeatherApiService.TryIt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Enter Latitude and Longitude</h2>
    <div>
        <asp:TextBox ID="LatitudeTextBox" runat="server" placeholder="Latitude"></asp:TextBox>
    </div>
    <div>
        <asp:TextBox ID="LongitudeTextBox" runat="server" placeholder="Longitude"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
    </div>
    <div>
        <asp:Literal ID="ResultLiteral" runat="server"></asp:Literal>
    </div>
</asp:Content>