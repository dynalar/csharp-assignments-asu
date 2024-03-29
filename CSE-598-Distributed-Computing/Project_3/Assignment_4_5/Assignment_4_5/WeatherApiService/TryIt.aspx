﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TryIt.aspx.cs" Inherits="Assignment_4_5.WeatherApiService.TryIt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Weather Service</h3>
    <h5>Enter Latitude and Longitude</h5>
    <h6>Example: Los Angeles</h6>
    <h6>Latitude: 34.052235 Longitude: -118.243683</h6>
    <div>
        <asp:Label id="label3" AssociatedControlId="LatitudeTextBox" Text="Latitude:" runat="server" />
        <asp:TextBox ID="LatitudeTextBox" runat="server" placeholder="Latitude"></asp:TextBox>
    </div>
    <div>
        <asp:Label id="label4" AssociatedControlId="LongitudeTextBox" Text="Longitude:" runat="server" />
        <asp:TextBox ID="LongitudeTextBox" runat="server" placeholder="Longitude"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
    </div>
    <div>
        <asp:Literal ID="ResultLiteral" runat="server"></asp:Literal>
    </div>
</asp:Content>