<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TryIt.aspx.cs" Inherits="Assignment_4_5.PhoneNotificationService.TryIt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Phone Notification Service</h3>
    <h5>Step 1 - Fill out the details below</h5>
    <h6>The current temperature field is for testing purposes.</h6>
    <div>
        <asp:Label id="label7" AssociatedControlId="PhoneNumberTextBox" Text="Phone Number:" runat="server" />
        <asp:TextBox ID="PhoneNumberTextBox" runat="server" placeholder="8185551234"></asp:TextBox>
    </div>
    <div>
        <asp:Label id="label12" AssociatedControlId="CarrierTextBox" Text="Carrier:" runat="server" />
        <asp:DropDownList ID="CarrierTextBox" runat="server">
            <asp:ListItem Text="-Select a Carrier-" Value=""></asp:ListItem>
            <asp:ListItem Text="T-Mobile" Value="tmobile"></asp:ListItem>
            <asp:ListItem Text="AT&T" Value="att"></asp:ListItem>
            <asp:ListItem Text="Verizon" Value="verizon"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>
        <asp:Label id="label8" AssociatedControlId="LatitudeTextBox" Text="Latitude:" runat="server" />
        <asp:TextBox ID="LatitudeTextBox" runat="server" placeholder="Latitude"></asp:TextBox>
    </div>
    <div>
        <asp:Label id="label4" AssociatedControlId="LongitudeTextBox" Text="Longitude:" runat="server" />
        <asp:TextBox ID="LongitudeTextBox" runat="server" placeholder="Longitude"></asp:TextBox>
    </div>
    <div>
        <asp:Label id="label14" AssociatedControlId="CurrentTemperatureTextBox" Text="Current Temperature:" runat="server" />
        <asp:TextBox ID="CurrentTemperatureTextBox" runat="server" placeholder="Temperature"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
    </div>
    <div>
        <asp:Literal ID="ResultLiteral" runat="server"></asp:Literal>
    </div>

    <h3>Simulate Notification</h3>
    <h5>Step 2 - Enter your phone number again, and enter a different temperature than before.</h3>
    <h6>Pass in your phone number, and temperature to test the notification.</h6>
    <div>
        <asp:Label id="phonesim" AssociatedControlId="PhoneNumberSimTextBox" Text="Phone Number:" runat="server" />
        <asp:TextBox ID="PhoneNumberSimTextBox" runat="server" placeholder="8185551234"></asp:TextBox>
    </div>
    <div>
        <asp:Label id="tempsim" AssociatedControlId="CurrentTemperatureSimTextBox" Text="Current Temperature:" runat="server" />
        <asp:TextBox ID="CurrentTemperatureSimTextBox" runat="server" placeholder="Temperature"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="SubmitButtonSimulate" runat="server" Text="Submit" OnClick="SimulateNotification_Click" />
    </div>
    <div>
        <asp:Literal ID="ResultLiteralSimulator" runat="server"></asp:Literal>
    </div>

</asp:Content>