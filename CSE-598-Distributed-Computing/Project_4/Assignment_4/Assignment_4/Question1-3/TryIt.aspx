<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TryIt.aspx.cs" Inherits="Assignment_4.Question1_3.TryIt" %>

<asp:Content ID="Question1_3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Question 1.3</h3>
    <h5>Parses and displays elements of an XML file.</h5>
    <h5>To get default Persons.xml file, just click Submit below.</h5>
    <div>
        <asp:Label id="label1" AssociatedControlId="XmlUrlTextBox" Text="XML URL:" runat="server" />
        <asp:TextBox ID="XmlUrlTextBox" class="xml-url-text-box" runat="server" placeholder="Enter URL to XML file..." value="Persons.xml"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
    </div>
    <div>
        <asp:Label runat="server" ID="ResultLabel" />
    </div>
</asp:Content>